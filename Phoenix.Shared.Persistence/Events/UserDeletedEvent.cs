namespace Phoenix.Shared.Persistence.Events;

public class UserDeletedEvent : IntegrationEvent
{
    public UserDeletedEvent(Guid id) : base(id, DateTime.UtcNow) { }
}