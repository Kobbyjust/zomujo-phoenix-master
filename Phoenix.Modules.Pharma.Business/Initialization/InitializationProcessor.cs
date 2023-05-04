using Microsoft.Extensions.Logging;
using Phoenix.Shared.Business;

namespace Phoenix.Modules.Pharma.Business.Initialization;

[Processor]
public class PharmaInitializationProcessor
{
    private readonly ILogger<PharmaInitializationProcessor> _logger;

    public PharmaInitializationProcessor(ILogger<PharmaInitializationProcessor> logger)
    {
        _logger = logger;
    }

    public async Task InitializeDb()
    {
        await Task.CompletedTask;
    }
}