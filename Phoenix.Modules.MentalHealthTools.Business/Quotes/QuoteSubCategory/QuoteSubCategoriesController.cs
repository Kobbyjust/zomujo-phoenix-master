using Microsoft.AspNetCore.Mvc;
using Controller = Phoenix.Shared.Business.Controller;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteSubCategory;

public class QuoteSubCategoriesController : Controller
{
    private readonly QuoteSubCategoryProcessor _processor;

    public QuoteSubCategoriesController(QuoteSubCategoryProcessor processor)
    {
        _processor = processor;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _processor.GetAsync(id);
        return result.IsT0 ? Ok(result.AsT0) : BuildProblemDetails(id);
    }

    [HttpPost]
    public async Task<IActionResult> GetPage([FromBody] PaginatedCommand command)
    {
        var result = await _processor.GetPageAsync(command);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] QuoteSubCategoryCommand command)
    {
        var result = await _processor.UpsertAsync(command);
        return CreatedAtRoute(nameof(Get), result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _processor.DeleteAsync(id);
        return NoContent();
    }
}