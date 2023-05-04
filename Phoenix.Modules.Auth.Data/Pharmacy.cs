using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Auth.Data;

public class Pharmacy : Entity
{
    private Pharmacy(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
    
    public string Name { get; private set; }
    public string? Email { get; private set; }
    public string Phone { get; private set; }
    public byte[]? Password { get; private set; }
    public byte[]? PasswordKey { get; private set; }
    public bool IsApproved { get; private set; }
    public Location? Location { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public bool IsPhoneVerified { get; private set; }

    public static Pharmacy Create(string name, string phone) => new(name, phone);

    public Pharmacy WithName(string name)
    {
        Name = name;
        return this;
    }

    public Pharmacy WithEmail(string? email)
    {
        Email = email;
        return this;
    }

    public Pharmacy WithPhone(string phone)
    {
        Phone = phone;
        return this;
    }

    public Pharmacy SetPassword(byte[] password, byte[] passwordKey)
    {
        Password = password;
        PasswordKey = passwordKey;
        return this;
    }
    
    public Pharmacy VerifyEmail()
    {
        IsEmailVerified = true;
        return this;
    }
    
    public Pharmacy UnverifyEmail()
    {
        IsEmailVerified = false;
        return this;
    }
    
    public Pharmacy VerifyPhone()
    {
        IsPhoneVerified = true;
        return this;
    }
    
    public Pharmacy UnverifyPhone()
    {
        IsPhoneVerified = false;
        return this;
    }
    
    public Pharmacy Approve()
    {
        IsApproved = true;
        return this;
    }
    
    public Pharmacy Disapprove()
    {
        IsApproved = false;
        return this;
    }
}

public class Location : ValueObject
{
    private Location() { }
    private Location(string address, float lat, float lng)
    {
        Address = address;
        Lat = lat;
        Lng = lng;
    }
    
    public string Address { get; }
    public float Lat { get; }
    public float Lng { get; }

    public static Location Create(string address, float lat, float lng) => new(address, lat, lng);
}

public class PharmacyConfiguration : DatabaseConfiguration<Pharmacy, string>
{
    public override void Configure(EntityTypeBuilder<Pharmacy> builder)
    {
        base.Configure(builder);
        builder.OwnsOne(x => x.Location, a =>
            {
                a.Property(x => x.Address).IsRequired();
            });
        builder.Property(x => x.Name).IsRequired();
    }
}