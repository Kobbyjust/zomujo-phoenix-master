using MediatR;

namespace Phoenix.Shared.Persistence.Events;

public abstract class IntegrationEvent : INotification
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }

    protected IntegrationEvent(Guid id, DateTime occurredOn)
    {
        Id = id;
        OccurredOn = occurredOn;
    }
}

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}

public interface IIntegrationEventHandler
{
}