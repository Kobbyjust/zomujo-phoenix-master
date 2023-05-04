using MediatR;
using Newtonsoft.Json;
using Phoenix.Shared.Persistence;
using Phoenix.Shared.Persistence.Events;
using Quartz;

namespace Phoenix.Auth.Business.Jobs;

[DisallowConcurrentExecution]
public class ProcessAuthBoxMessagesJob : IJob
{
    private readonly AuthDbContext _dbContext;
    private readonly IPublisher _publisher;
    private readonly ILogger<ProcessAuthBoxMessagesJob> _logger;

    public ProcessAuthBoxMessagesJob(AuthDbContext dbContext, IPublisher publisher,
        ILogger<ProcessAuthBoxMessagesJob> logger)
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
        var results = await _dbContext.AuthOutbox
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
        var results = await _dbContext.AuthInbox
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