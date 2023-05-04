using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Modules.Docs.Data;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;

namespace Phoenix.Modules.Docs.Business.Extensions;

public static class Startup
{
    public static void RunDocsStartup(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<DocsDbContext>();
        SubscribeToIntegrationEvents( serviceScope.ServiceProvider.GetRequiredService<IEventsBus>(),
            serviceScope.ServiceProvider.GetRequiredService<Serilog.ILogger>(), 
            context!);
        
        if (Environment.CommandLine.Contains("migrations add")) return;
        context?.Database.Migrate();
    }
    
    private static void SubscribeToIntegrationEvents(IEventsBus eventBus, 
        Serilog.ILogger logger, DocsDbContext dbContext)
    {
        SubscribeToIntegrationEvent<UserDeletedEvent>(eventBus, logger, dbContext);
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, Serilog.ILogger logger, DocsDbContext dbContext)
        where T : IntegrationEvent
    {
        logger.Information("Docs::Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>(dbContext));
    }
}