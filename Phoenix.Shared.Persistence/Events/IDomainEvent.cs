using MediatR;

namespace Phoenix.Shared.Persistence.Events;

public interface IDomainEvent : INotification
{
    string Id { get; }
    string EntityId { get; }
    DateTime OccurredOn { get; }
}

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent(string id)
    {
        Id = Guid.NewGuid().ToString();
        EntityId = id;
        OccurredOn = DateTime.UtcNow;
    }
    
    public string Id { get; }
    public string EntityId { get; }
    public DateTime OccurredOn { get; }
}