using Microsoft.OpenApi.Models;

namespace TaxdoAssignment.UserApi;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Taxdo UserManagement API", Version = "v1" });
        });

        return services;
    }
}
