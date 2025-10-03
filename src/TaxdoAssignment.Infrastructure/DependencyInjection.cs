using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxdoAssignment.Application.Shared;
using TaxdoAssignment.Domain;
using TaxdoAssignment.Domain.Shared;
using TaxdoAssignment.Infrastructur;

namespace TaxdoAssignment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(connectionString: configuration.GetConnectionString("development"))
        );

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<AppDbContext>());

        services.AddSingleton<IGuidGenerator, GuidGenerator>();

        var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
        services.AddSingleton(emailSettings);

        //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddScoped<IEmailSender, EmailSender>();

        services.AddSingleton<IPasswordHasher, SimplePasswordHasher>();

        return services;
    }
}
