using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Auth.Data;

public class Counsellor : Entity
{
    private Counsellor(string firstName, string lastName, string phone)
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
    public bool IsApproved { get; private set; }
    public Rate Rate { get; private set; }
    public byte[]? Password { get; private set; }
    public byte[]? PasswordKey { get; private set; }


    public static Counsellor Create(string firstName, string lastName, string phone) 
        => new(firstName, lastName, phone);

    public Counsellor WithName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        return this;
    }

    public Counsellor WithEmail(string? email)
    {
        Email = email;
        return this;
    }

    public Counsellor WithPhoneNumber(string? phone)
    {
        Phone = phone;
        return this;
    }

    public Counsellor SetPassword(byte[] password, byte[] passwordKey)
    {
        Password = password;
        PasswordKey = passwordKey;
        return this;
    }

    public Counsellor Approve()
    {
        IsApproved = true;
        return this;
    }
    
    public Counsellor Disapprove()
    {
        IsApproved = false;
        return this;
    }
}

public class Rate : ValueObject
{
    private Rate() { }
    private Rate(int value, int total)
    {
        Value = value;
        Total = total;
    }
    
    public int Value { get; }
    public int Total { get; }

    public static Rate Create(int value, int total) => new(value, total);
}

public class CounsellorConfiguration : DatabaseConfiguration<Counsellor, string>
{
    public override void Configure(EntityTypeBuilder<Counsellor> builder)
    {
        base.Configure(builder);
        builder.Ignore(x => x.FullName);
        builder.OwnsOne(x => x.Rate, a =>
            {
                a.Property(x => x.Value)
                    .IsRequired();
            });
    }
}