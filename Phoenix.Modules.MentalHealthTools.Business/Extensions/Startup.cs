using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Phoenix.Shared.Persistence.BoxMessages;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;

namespace Phoenix.Modules.MentalHealthTools.Business.Extensions;

public static class Startup
{
    public static void RunMhToolsStartup(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<MhToolsDbContext>();
        SubscribeToIntegrationEvents( serviceScope.ServiceProvider.GetRequiredService<IEventsBus>(),
            serviceScope.ServiceProvider.GetRequiredService<Serilog.ILogger>(), 
            context!);
        
        if (Environment.CommandLine.Contains("migrations add")) return;
        context?.Database.Migrate();
    }
    
    private static void SubscribeToIntegrationEvents(IEventsBus eventBus, 
        Serilog.ILogger logger, MhToolsDbContext dbContext)
    {
        SubscribeToIntegrationEvent<UserDeletedEvent>(eventBus, logger, dbContext);
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, Serilog.ILogger logger, MhToolsDbContext dbContext)
        where T : IntegrationEvent
    {
        logger.Information("MHTools::Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>(dbContext));
    }
}

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
    where T : IntegrationEvent
{
    private readonly MhToolsDbContext _dbContext;

    public IntegrationEventGenericHandler(MhToolsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(T @event)
    {
        string type = @event.GetType().FullName ?? "";
        var data = JsonSerializer.Serialize(@event);

        await _dbContext.MHToolsInbox.AddAsync(new InboxMessage
        {
            Content = data,
            DateOccurred = @event.OccurredOn,
            Type = type,
            Id = @event.Id.ToString()
        });

        await _dbContext.SaveChangesAsync();
    }
}
