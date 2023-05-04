using Microsoft.Extensions.Logging;

namespace Phoenix.Shared.Persistence.Events.Bus;

public class InMemoryEventBusClient : IEventsBus
{
    private readonly ILogger<InMemoryEventBusClient> _logger;

    public InMemoryEventBusClient(ILogger<InMemoryEventBusClient> logger)
    {
        _logger = logger;
    }

    public void Dispose()
    {
    }

    public async Task PublishAsync<T>(T @event)
        where T : IntegrationEvent
    {
        _logger.LogInformation("Publishing {Event}", @event.GetType().FullName);
        await InMemoryEventBus.Instance.Publish(@event);
    }

    public void Subscribe<T>(IIntegrationEventHandler<T> handler)
        where T : IntegrationEvent
    {
        InMemoryEventBus.Instance.Subscribe(handler);
    }

    public void StartConsuming()
    {
    }
}

public interface IEventsBus : IDisposable
{
    Task PublishAsync<T>(T @event)
        where T : IntegrationEvent;

    void Subscribe<T>(IIntegrationEventHandler<T> handler)
        where T : IntegrationEvent;

    void StartConsuming();
}