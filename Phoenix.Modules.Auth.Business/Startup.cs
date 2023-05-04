using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Shared.Persistence.BoxMessages;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;

namespace Phoenix.Auth.Business;

public static class Startup
{
    public static void RunAuthStartup(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AuthDbContext>();
        SubscribeToIntegrationEvents( serviceScope.ServiceProvider.GetRequiredService<IEventsBus>(),
            serviceScope.ServiceProvider.GetRequiredService<Serilog.ILogger>(), 
            context!);
        
        if (Environment.CommandLine.Contains("migrations add")) return;
        context?.Database.Migrate();
    }
    
    private static void SubscribeToIntegrationEvents(IEventsBus eventBus, 
        Serilog.ILogger logger, AuthDbContext dbContext)
    {
        SubscribeToIntegrationEvent<UserDeletedEvent>(eventBus, logger, dbContext);
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, Serilog.ILogger logger, AuthDbContext dbContext)
        where T : IntegrationEvent
    {
        logger.Information("Auth::Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>(dbContext));
    }
}

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
    where T : IntegrationEvent
{
    private readonly AuthDbContext _dbContext;

    public IntegrationEventGenericHandler(AuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(T @event)
    {
        var type = @event.GetType().FullName ?? "";
        var data = JsonSerializer.Serialize(@event);

        await _dbContext.AuthInbox.AddAsync(new InboxMessage
        {
            Content = data,
            DateOccurred = @event.OccurredOn,
            Type = type,
            Id = @event.Id.ToString()
        });

        await _dbContext.SaveChangesAsync();
    }
}
