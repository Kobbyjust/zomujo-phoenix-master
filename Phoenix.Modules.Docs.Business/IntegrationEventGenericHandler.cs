using Newtonsoft.Json;
using Phoenix.Modules.Docs.Data;
using Phoenix.Shared.Persistence.BoxMessages;
using Phoenix.Shared.Persistence.Events;

namespace Phoenix.Modules.Docs.Business;

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
    where T : IntegrationEvent
{
    private readonly DocsDbContext _dbContext;

    public IntegrationEventGenericHandler(DocsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(T @event)
    {
        string type = @event.GetType().FullName ?? "";
        var data = JsonSerializer.Serialize(@event);

        await _dbContext.DocsInbox.AddAsync(new InboxMessage
        {
            Content = data,
            DateOccurred = @event.OccurredOn,
            Type = type,
            Id = @event.Id.ToString()
        });

        await _dbContext.SaveChangesAsync();
    }
}
