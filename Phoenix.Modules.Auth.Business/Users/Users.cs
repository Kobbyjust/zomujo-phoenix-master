using FluentValidation;
using Phoenix.Modules.Auth.Data.Users;

namespace Phoenix.Auth.Business.Users;

public class SignupCommand
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
}

public class UserCommand
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string LastName { get; set; }
}

public class UserDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }

    public static explicit operator UserDto(User? user)
    {
        if (user is null) return null;
        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
    }
}

public class UserPageDto
{
    public string Id { get; set; }
    public string? UserName { get; set; }
    
    public static explicit operator UserPageDto(User user)
    {
        return new UserPageDto
        {
            Id = user.Id,
            UserName = user.UserName,
        };
    }
}

public class UserCommandValidator : AbstractValidator<UserCommand>
{
    public UserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .NotEmpty();
    }
}

public class SignupCommandValidator : AbstractValidator<SignupCommand>
{
    public SignupCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();
    }
}