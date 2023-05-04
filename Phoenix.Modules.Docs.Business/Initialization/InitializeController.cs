using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Controller = Phoenix.Shared.Business.Controller;

namespace Phoenix.Modules.Docs.Business.Initialization;

internal class DocsInitializeController : Controller
{
    private readonly DocsInitializationProcessor _processor;

    public DocsInitializeController(DocsInitializationProcessor processor)
    {
        _processor = processor;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Start()
    {
        await _processor.InitializeDb();
        return NoContent();
    }
}