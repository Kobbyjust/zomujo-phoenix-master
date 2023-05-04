using MediatR;
using Microsoft.Extensions.Logging;
using Phoenix.Modules.Docs.Data;
using Phoenix.Shared.Persistence.Events;

namespace Phoenix.Modules.Docs.Business.EventHandlers;

internal class UserDeletedEventHandlerForDocs : INotificationHandler<UserDeletedEvent>
{
    private readonly DocsDbContext _dbContext;
    private readonly ILogger<UserDeletedEventHandlerForDocs> _logger;

    public UserDeletedEventHandlerForDocs(DocsDbContext dbContext, ILogger<UserDeletedEventHandlerForDocs> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Docs:: Reacting to published event ({Event}) with id: {Id}", 
            nameof(UserDeletedEvent), notification.Id);
        // Delete all entries in db that reference user with incoming id
        await Task.CompletedTask;
    }
}