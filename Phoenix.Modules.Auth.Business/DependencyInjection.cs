using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Auth.Business.Jobs;
using Phoenix.Auth.Business.Services;
using Phoenix.Auth.Business.Users;
using Phoenix.Auth.Business.Users.Events;
using Phoenix.Modules.Auth.Data.Installers;
using Phoenix.Modules.Auth.Data.Users;
using Phoenix.Shared.Business;
using Phoenix.Shared.Persistence.Events;
using Quartz;

namespace Phoenix.Auth.Business;

public static class DependencyInjection
{
    public static IServiceCollection InstallAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.InstallPersistence(configuration)
            .AddAuthenticationService(configuration)
            .InstallProcessors()
            .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly)
            .AddSingleton<AuthCloudMessagingService>();
        services.AddTransient<INotificationHandler<UserDeletedDomainEvent>, UserDeletedDomainEventHandler>();
        return services;
    }

    private static IServiceCollection InstallProcessors(this IServiceCollection services)
    {
        var types = typeof(UserProcessor).Assembly.DefinedTypes;
        var processors = types.Where(x =>
            x.IsClass && x.CustomAttributes.Any(a => a.AttributeType == typeof(ProcessorAttribute)));
        
        foreach (var processor in processors)
        {
            services.AddScoped(processor);
        }
        return services;
    }
}

