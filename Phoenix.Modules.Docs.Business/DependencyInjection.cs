using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Modules.Docs.Business.CounsellingUnit;
using Phoenix.Modules.Docs.Business.EventHandlers;
using Phoenix.Modules.Docs.Business.Jobs;
using Phoenix.Modules.Docs.Business.Services;
using Phoenix.Modules.Docs.Data;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;
using Quartz;

namespace Phoenix.Modules.Docs.Business;

public static class DependencyInjection
{
    public static IServiceCollection InstallDocs(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration)
            .AddSingleton<DocsCloudMessagingService>()
            .AddScoped<IStoreService, StoreService>();
        services.AddTransient<INotificationHandler<UserDeletedEvent>, UserDeletedEventHandlerForDocs>();
        return services;
    }
}