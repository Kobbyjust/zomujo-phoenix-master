using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Controller = Phoenix.Shared.Business.Controller;

namespace Phoenix.Modules.Pharma.Business.Initialization;

public class PharmaInitializeController : Controller
{
    private readonly PharmaInitializationProcessor _processor;

    public PharmaInitializeController(PharmaInitializationProcessor processor)
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