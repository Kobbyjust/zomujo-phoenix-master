namespace Phoenix.Auth.Business.Users;

public class UsersController : Controller
{
    private readonly UserProcessor _processor;

    public UsersController(UserProcessor processor)
    {
        _processor = processor;
    }

    [HttpPost("signup/google")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUpWithGoogle([FromBody] GoogleSignInResponseModel model)
    {
        var result = await _processor.GoogleSignupAsync(model);
        if (result.IsT1)
            return BuildProblemDetails(result.AsT1);

        var isSucceeded = result.AsT0;

        return isSucceeded ? Ok(new {Message = "User signed up successfully"}) 
            : BuildProblemDetails(new Exception(""));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _processor.LoginAsync(command);
        return result.IsT0 ? Ok(result.AsT0) : BuildProblemDetails(result.AsT1);
    }
    
    [Authorize("AdminOnly")]
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MakeAdmin([FromRoute] string id)
    {
        var success = await _processor.MakeAdmin(id);
        return success ? NoContent() : BadRequest();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _processor.DeleteAsync(id);
        if (result.IsT1) return BuildProblemDetails(result.AsT1);

        return result.AsT0 == false ? BuildProblemDetails(new Exception("Internal Server Error")) 
            : NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(SignupCommand command)
    {
        var result = await _processor.CreateNew(command);
        return result.IsT1 ? BuildProblemDetails(result.AsT1) 
            : CreatedAtAction(nameof(Get), new {id = result.AsT0}, result.AsT0);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _processor.GetAsync(id);
        return Ok(user);
    }
}