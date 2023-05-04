using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Phoenix.Shared.Persistence.BoxMessages;
using Phoenix.Shared.Persistence.Events;
using StackExchange.Redis;

namespace Phoenix.Shared.Persistence.Interceptors;

public sealed class ConvertDomainEventsToOutboxMessagesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        var dbContext = eventData.Context;
        if (dbContext is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        var messages = dbContext.ChangeTracker
            .Entries<Entity>()
            .Select(x => x.Entity)
            .SelectMany(x =>
            {
                var events = new List<IDomainEvent>();
                events.AddRange(x.DomainEvents);
                x.ClearDomainEvents();
                return events.AsEnumerable();
            })
            .Select(domainEvent => new OutboxMessage
            {
                Id = domainEvent.Id,
                DateOccurred = DateTime.UtcNow,
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })
            }).ToList();
        
        foreach (var outboxMessage in messages)
        {
            dbContext.Set<OutboxMessage>().AddAsync(outboxMessage, cancellationToken)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}