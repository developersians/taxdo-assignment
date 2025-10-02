using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;

namespace TaxdoAssignment.UserApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddCustomControllers();        
        services.AddCustomSwagger();

        return services;
    }

    private static IServiceCollection AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(
                new RouteTokenTransformerConvention(new KebabCaseParameterTransformer())
            );
        });

        return services;
    }

    private static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Taxdo UserManagement API", Version = "v1" });
        });

        return services;
    }
}
