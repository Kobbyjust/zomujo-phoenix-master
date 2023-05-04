using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Auth.Data;

public class Doctor : Entity
{
    private Doctor(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    [NotMapped]
    public string FullName => string.Join(" ", FirstName, LastName);
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
    public string? ProfilePhoto { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public bool IsPhoneVerified { get; private set; }
    public byte[]? Password { get; private set; }
    public byte[]? PasswordKey { get; private set; }

    public static Doctor Create(string firstName, string lastName, string phone) 
        => new(firstName, lastName, phone);

    public Doctor WithName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        return this;
    }

    public Doctor WithEmail(string? email)
    {
        Email = email;
        return this;
    }

    public Doctor WithPhoneNumber(string? phone)
    {
        Phone = phone;
        return this;
    }

    public Doctor SetPassword(byte[] password, byte[] passwordKey)
    {
        Password = password;
        PasswordKey = passwordKey;
        return this;
    }
    
    public Doctor HasPhoto(string? photo)
    {
        ProfilePhoto = photo;
        return this;
    }

    public Doctor VerifyEmail()
    {
        IsEmailVerified = true;
        return this;
    }
    
    public Doctor UnverifyEmail()
    {
        IsEmailVerified = false;
        return this;
    }
    
    public Doctor VerifyPhone()
    {
        IsPhoneVerified = true;
        return this;
    }
    
    public Doctor UnverifyPhone()
    {
        IsPhoneVerified = false;
        return this;
    }
}

public class DoctorConfiguration : DatabaseConfiguration<Doctor, string>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);
        builder.Ignore(x => x.FullName);
        builder.Property(x => x.FirstName)
            .HasMaxLength(80)
            .HasColumnType("varchar");
        builder.Property(x => x.LastName)
            .HasMaxLength(80)
            .HasColumnType("varchar");
    }
}