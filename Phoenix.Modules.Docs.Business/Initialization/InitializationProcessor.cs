using Microsoft.Extensions.Logging;
using Phoenix.Shared.Business;

namespace Phoenix.Modules.Docs.Business.Initialization;

[Processor]
internal class DocsInitializationProcessor
{
    private readonly ILogger<DocsInitializationProcessor> _logger;

    public DocsInitializationProcessor(ILogger<DocsInitializationProcessor> logger)
    {
        _logger = logger;
    }

    public async Task InitializeDb()
    {
        await Task.CompletedTask;
    }
}