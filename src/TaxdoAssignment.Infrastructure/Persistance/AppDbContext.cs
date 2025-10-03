using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TaxdoAssignment.Domain;
using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Infrastructure;

public class AppDbContext(
    DbContextOptions<AppDbContext> options,
    ILogger<AppDbContext> logger) : DbContext(options), IUnitOfWork
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<OutboxMessageEntity> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ExtractDomainEvents();
        var messages = CreateOutboxMessages(domainEvents);
        if (messages is not null)
            await OutboxMessages.AddRangeAsync(messages, cancellationToken);

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    private List<IDomainEvent> ExtractDomainEvents()
    {
        var domainEntities = ChangeTracker.Entries<Entity>()
            .Where(x => x.Entity.GetDomainEvents().Count != 0)
            .Select(x => x.Entity)
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.GetDomainEvents())
            .ToList();

        domainEntities.ForEach(entity => entity.ClearDomainEvents());

        return domainEvents;
    }

    private IEnumerable<OutboxMessageEntity>? CreateOutboxMessages(List<IDomainEvent> domainEvents)
    {
        if (domainEvents.Count == 0)
            return null;

        return domainEvents.Select(domainEvent =>
            new OutboxMessageEntity(
                domainEvent.GetType().AssemblyQualifiedName!,
                JsonSerializer.Serialize(domainEvent),
                domainEvent.OccurredOn)
        );
    }

}
