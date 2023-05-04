using FluentValidation.AspNetCore;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Phoenix.Shared.Persistence.Events.Bus;
using Quartz;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Phoenix.Shared.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        services.AddEndpointsApiExplorer();
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            opt.NotificationPublisher = new TaskWhenAllPublisher();
        });
        services.AddSignalR();
        services.AddSingleton<IEventsBus, InMemoryEventBusClient>();
        services.AddSwaggerConfig()
            .AddCacheStore(configuration)
            .AddHttpContextAccessor()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
        return services;
    }
    
    private static IServiceCollection AddCacheStore(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Switch to prod url
        var options = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisDev") ?? "");
        options.ClientName = "Zomujo";
        options.DefaultDatabase = 1;
        var multiplexer = ConnectionMultiplexer.Connect(options.ToString());
        services.AddSingleton(multiplexer.GetDatabase());
        return services;
    }
    
    // TODO:: Refactor: use GetSection to move strings to configuration file
    private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Zomujo LLC.",
                Version = "1",
                Contact = new OpenApiContact
                {
                    Name = "Kofi Gyasi",
                    Email = "kofigyasidev@gmail.com",
                    Url = new Uri("https://kaygyasi.vercel.app/")
                }
            });
            opt.CustomOperationIds(apiDescription => apiDescription.TryGetMethodInfo(out var methodInfo)
                ? methodInfo.Name
                : apiDescription.RelativePath);
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization using the bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }
}