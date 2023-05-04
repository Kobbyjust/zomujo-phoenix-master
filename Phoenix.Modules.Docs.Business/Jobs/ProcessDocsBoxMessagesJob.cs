using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Phoenix.Modules.Docs.Data;
using Phoenix.Shared.Persistence.Events;
using Quartz;

namespace Phoenix.Modules.Docs.Business.Jobs;

[DisallowConcurrentExecution]
public class ProcessDocsBoxMessagesJob : IJob
{
    private readonly DocsDbContext _dbContext;
    private readonly IPublisher _publisher;
    private readonly ILogger<ProcessDocsBoxMessagesJob> _logger;

    public ProcessDocsBoxMessagesJob(DocsDbContext dbContext, IPublisher publisher,
        ILogger<ProcessDocsBoxMessagesJob> logger)
    {
        _dbContext = dbContext;
        _publisher = publisher;
        _logger = logger;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        await ProcessOutboxMessages(context);
        await ProcessInboxMessages(context);
    }

    private async Task ProcessOutboxMessages(IJobExecutionContext context)
    {
        var results = await _dbContext.DocsOutbox
            .Where(x => x.DateProcessed == null)
            .ToListAsync();
        if (!results.Any()) return;

        foreach (var message in results)
        {
            var @event = JsonConvert.DeserializeObject<IDomainEvent>(message.Content, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            if (@event is null) continue;

            try
            {
                await _publisher.Publish(@event, context.CancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error while trying to publish domain event with id: {Id}, Message: {Message}",
                    @event.Id, e.Message);
                continue;
            }

            message.DateProcessed = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }
    }
    
    private async Task ProcessInboxMessages(IJobExecutionContext context)
    {
        var results = await _dbContext.DocsInbox
            .Where(x => x.DateProcessed == null)
            .ToListAsync();
        if (!results.Any()) return;

        foreach (var message in results)
        {
            var @event = JsonConvert.DeserializeObject<IntegrationEvent>(message.Content, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            if (@event is null) continue;

            try
            {
                await _publisher.Publish(@event, context.CancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Error while trying to publish integration event with id: {Id}, Message: {Message}",
                    @event.Id, e.Message);
                continue;
            }

            message.DateProcessed = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }
    }
}