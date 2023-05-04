using Microsoft.AspNetCore.Mvc;
using Controller = Phoenix.Shared.Business.Controller;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteCategory;

public class QuoteCategoriesController : Controller
{
    private readonly QuoteCategoryProcessor _processor;

    public QuoteCategoriesController(QuoteCategoryProcessor processor)
    {
        _processor = processor;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _processor.GetAsync(id);
        return result.IsT0 ? Ok(result.AsT0) : BuildProblemDetails(id);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPage([FromBody] PaginatedCommand command)
    {
        var result = await _processor.GetPageAsync(command);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] QuoteCategoryCommand command)
    {
        var result = await _processor.UpsertAsync(command);
        return CreatedAtAction(nameof(Get), new {id = result}, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _processor.DeleteAsync(id);
        return NoContent();
    }
}