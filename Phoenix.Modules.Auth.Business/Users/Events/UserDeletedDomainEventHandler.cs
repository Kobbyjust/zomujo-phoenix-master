using MediatR;
using Phoenix.Modules.Auth.Data.Users;
using Phoenix.Shared.Persistence;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;

namespace Phoenix.Auth.Business.Users.Events;

public class UserDeletedDomainEventHandler : INotificationHandler<UserDeletedDomainEvent>
{
    private readonly IEventsBus _eventsBus;
    private readonly ILogger<UserDeletedDomainEventHandler> _logger;

    public UserDeletedDomainEventHandler(IEventsBus eventsBus, ILogger<UserDeletedDomainEventHandler> logger)
    {
        _eventsBus = eventsBus;
        _logger = logger;
    }
    
    public async Task Handle(UserDeletedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Auth:: Reacting to published event ({Event}) with id: {Id}", 
            nameof(UserDeletedEvent), notification.Id);
        
        await _eventsBus.PublishAsync(new UserDeletedEvent(Guid.NewGuid()));
    }
}