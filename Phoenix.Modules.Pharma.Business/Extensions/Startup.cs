using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Modules.Pharma.Data;
using Phoenix.Shared.Persistence.BoxMessages;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;

namespace Phoenix.Modules.Pharma.Business.Extensions;

public static class Startup
{
    public static void RunPharmaStartup(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<PharmaDbContext>();
        SubscribeToIntegrationEvents( serviceScope.ServiceProvider.GetRequiredService<IEventsBus>(),
            serviceScope.ServiceProvider.GetRequiredService<Serilog.ILogger>(), 
            context!);
        
        if (Environment.CommandLine.Contains("migrations add")) return;
        context?.Database.Migrate();
    }
    
    private static void SubscribeToIntegrationEvents(IEventsBus eventBus, 
        Serilog.ILogger logger, PharmaDbContext dbContext)
    {
        SubscribeToIntegrationEvent<UserDeletedEvent>(eventBus, logger, dbContext);
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, Serilog.ILogger logger, PharmaDbContext dbContext)
        where T : IntegrationEvent
    {
        logger.Information("Pharma::Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>(dbContext));
    }
}

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
    where T : IntegrationEvent
{
    private readonly PharmaDbContext _dbContext;

    public IntegrationEventGenericHandler(PharmaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(T @event)
    {
        string type = @event.GetType().FullName ?? "";
        var data = JsonSerializer.Serialize(@event);

        await _dbContext.PharmaInbox.AddAsync(new InboxMessage
        {
            Content = data,
            DateOccurred = @event.OccurredOn,
            Type = type,
            Id = @event.Id.ToString()
        });

        await _dbContext.SaveChangesAsync();
    }
}
