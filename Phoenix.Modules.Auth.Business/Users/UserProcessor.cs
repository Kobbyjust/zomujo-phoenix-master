using Phoenix.Auth.Business.Helpers;
using Phoenix.Modules.Auth.Data.Users;
using Phoenix.Shared.Business;
using Phoenix.Shared.Persistence.Events;
using Phoenix.Shared.Persistence.Events.Bus;

namespace Phoenix.Auth.Business.Users;

[Processor]
public class UserProcessor
{
    private readonly ITokenService _tokenService;
    private readonly AuthDbContext _dbContext;
    private readonly ILogger<UserProcessor> _logger;
    private readonly IEventsBus _eventsBus;

    public UserProcessor(ITokenService tokenService, AuthDbContext dbContext, ILogger<UserProcessor> logger,
        IEventsBus eventsBus)
    {
        _tokenService = tokenService;
        _dbContext = dbContext;
        _logger = logger;
        _eventsBus = eventsBus;
    }

    public async Task<OneOf<bool, InvalidDataException>> GoogleSignupAsync(GoogleSignInResponseModel model)
    {
        var googleUser = await GetGoogleUserProfile(model.AccessToken, model.UserId);
        if (googleUser is null) return false;

        var user = User.Create(googleUser.FirstName, googleUser.LastName)
            .HasEmail(googleUser.Email);

        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<OneOf<AuthToken, InvalidLoginException>> LoginAsync(LoginCommand command, bool isGoogle = false)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == command.Email);
        if (user is null) 
            return new InvalidLoginException($"User with email: {command.Email} does not exist");
        
        if (!isGoogle && !PasswordHelper.MatchPasswordHash(command.Password!, user.Password!, user.PasswordKey!))
            return new InvalidLoginException("Invalid password");

        return await Task.Run(() => _tokenService.GenerateToken(user));
    }

    public async Task<OneOf<string, Exception>> CreateNew(SignupCommand command)
    {
        var exists =
            await _dbContext.Users.AnyAsync(x => x.Email == command.Email);
        if (exists) return new InvalidDataException("User already exists");
        
        var user = User.Create(command.FirstName!, command.LastName!)
            .HasPhone(command.PhoneNumber!)
            .HasEmail(command.Email);
        var passwordInfo = PasswordHelper.GetPasswordInfo(command.Password ?? "");
        user.SetPassword(passwordInfo.Item1, passwordInfo.Item2);
        
        try
        {
            await _dbContext.Users.AddAsync(user);
            return await _dbContext.SaveChangesAsync() > 0 ? user.Id : string.Empty;
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            return e;
        }
    }

    public async Task<UserDto?> GetAsync(string id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user is null) return null;

        return (UserDto) user;
    }

    /// <summary>
    /// Soft deletes user with provided id
    /// </summary>
    /// <param name="id">Id of user to be deleted</param>
    /// <returns></returns>
    public async Task<OneOf<bool, InvalidIdException>> DeleteAsync(string id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user is null) return new InvalidIdException($"User with id: {id} not found");

        user.Delete();
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> MakeAdmin(string id)
    {
        // implement
        return true;
    }
    
    private static async Task<GoogleUserProfile?> GetGoogleUserProfile(string token, string userId)
    {
        using var client = new HttpClient();
        var uri = $"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={token}";
        var response = await client.GetAsync(uri);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<GoogleUserProfile>(content);
    }
}

public record GoogleUserProfile(string Email, string FirstName, string LastName);

public record GoogleSignInResponseModel(string AccessToken, string UserId);

public record LoginCommand(string Email, string? Password);