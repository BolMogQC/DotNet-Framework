using System.Reflection;
using Web.API;
using Microsoft.OpenApi.Models;

namespace Web.Common.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        var apiAssembly = Assembly.GetAssembly(typeof(ApiControllerBase));

        if (apiAssembly is null)
        {
            throw new Exception("Could not find API assembly");
        }

        services.AddControllers()
            .AddApplicationPart(apiAssembly);
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.API", Version = "v1" });
        });
        
        return services;
    }
    
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        return services;
    }
}