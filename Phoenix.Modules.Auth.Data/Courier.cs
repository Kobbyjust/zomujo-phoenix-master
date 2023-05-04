using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Auth.Data;

public class Courier : Entity
{
    private Courier(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
    
    public string Name { get; private set; }
    public string? Email { get; private set; }
    public string Phone { get; private set; }
    public string? Photo { get; private set; }
    public byte[]? Password { get; private set; }
    public byte[]? PasswordKey { get; private set; }
    public bool IsApproved { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public bool IsPhoneVerified { get; private set; }

    public static Courier Create(string name, string phone) => new (name, phone);

    public Courier WithName(string name)
    {
        Name = name;
        return this;
    }

    public Courier WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public Courier WithPhone(string phone)
    {
        Phone = phone;
        return this;
    }

    public Courier HasPhoto(string? photo)
    {
        Photo = photo;
        return this;
    }
    
    public Courier SetPassword(byte[] password, byte[] passwordKey)
    {
        Password = password;
        PasswordKey = passwordKey;
        return this;
    }
    
    public Courier Approve()
    {
        IsApproved = true;
        return this;
    }
    
    public Courier Disapprove()
    {
        IsApproved = false;
        return this;
    }
    
    public Courier VerifyEmail()
    {
        IsEmailVerified = true;
        return this;
    }
    
    public Courier UnverifyEmail()
    {
        IsEmailVerified = false;
        return this;
    }
    
    public Courier VerifyPhone()
    {
        IsPhoneVerified = true;
        return this;
    }
    
    public Courier UnverifyPhone()
    {
        IsPhoneVerified = false;
        return this;
    }
}

public class CourierConfiguration : DatabaseConfiguration<Courier, string>
{
    public override void Configure(EntityTypeBuilder<Courier> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(80);
        builder.Property(x => x.Email)
            .HasColumnType("varchar")
            .HasMaxLength(40);
        builder.Property(x => x.Phone)
            .HasColumnType("varchar")
            .HasMaxLength(15);
        builder.Property(x => x.Photo)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}