using Phoenix.Shared.Persistence;
using Phoenix.Shared.Persistence.Events;

namespace Phoenix.Modules.Auth.Data.Users;

public class User : Entity
{
    private User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string UserName => FirstName;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateTime? DateOfBirth { get; private set; }
    public string? PhoneNumber { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public string? Email { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string? ProfilePhoto { get; private set; }
    public byte[]? Password { get; private set; }
    public byte[]? PasswordKey { get; private set; }

    public static User Create(string firstName, string lastName) => new(firstName, lastName);

    public User WithName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        return this;
    }

    public User WasBornOn(DateTime? dob)
    {
        DateOfBirth = dob;
        return this;
    }

    public User HasPhoto(string? photo)
    {
        ProfilePhoto = photo;
        return this;
    }

    public User HasPhone(string phone)
    {
        PhoneNumber = phone;
        return this;
    }

    public User HasEmail(string? email)
    {
        Email = email;
        return this;
    }
    
    public User VerifyEmail()
    {
        EmailConfirmed = true;
        return this;
    }
    
    public User UnverifyEmail()
    {
        EmailConfirmed = false;
        return this;
    }
    
    public User VerifyPhone()
    {
        PhoneNumberConfirmed = true;
        return this;
    }
    
    public User UnverifyPhone()
    {
        PhoneNumberConfirmed = false;
        return this;
    }

    public User Delete()
    {
        Audit?.Delete();
        RaiseDomainEvent(new UserDeletedDomainEvent(Id));
        return this;
    }

    public User SetPassword(byte[] password, byte[] passwordKey)
    {
        Password = password;
        PasswordKey = passwordKey;
        return this;
    }
}

public class UserDeletedDomainEvent : DomainEvent
{
    public UserDeletedDomainEvent(string id) : base(id) { }
}

public class UserConfiguration : DatabaseConfiguration<User, string>
{
}