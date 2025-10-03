using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;
using TaxdoAssignment.Domain.Shared;
using TaxdoAssignment.Infrastructure;

namespace TaxdoAssignment.UserApi;

public class OutboxProcessorHostedService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<OutboxProcessorHostedService> logger) : BackgroundService
{
    private readonly TimeSpan _processInterval = TimeSpan.FromSeconds(5);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Outbox processor hosted service is starting");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessOutboxAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while processing outbox messages");
            }

            await Task.Delay(_processInterval, stoppingToken);
        }
    }

    private async Task ProcessOutboxAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        var messages = await dbContext.Set<OutboxMessageEntity>()
            .Where(m => m.ProcessedOn == null)
            .OrderBy(m => m.OccurredOn)
            .Take(10) // Process in batches
            .ToListAsync(stoppingToken);

        foreach (var message in messages)
        {
            Type? type = Type.GetType(message.Type);

            try
            {
                var domainEvent = (IDomainEvent?)JsonSerializer.Deserialize(message.Content, type!);
                if (domainEvent != null)
                {
                    await mediator.Publish(domainEvent, stoppingToken);
                }

                message.MarkAsProcessed();

                logger.LogInformation("Processed outbox message: {MessageId}", message.Id);
            }
            catch (Exception ex)
            {
                message.MarkAsFailed(ex.Message);

                logger.LogError(ex, "Error processing outbox message: {MessageId}", message.Id);
            }
        }

        if (messages.Count > 0)
            await dbContext.SaveChangesAsync(stoppingToken);
    }
}
