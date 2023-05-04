using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Auth.Data;

public class Admin : Entity
{
    private Admin(string name)
    {
        Name = name;
    }
    
    public string Name { get; private set; }
    public byte[]? Password { get; private set; }
    public byte[]? PasswordKey { get; private set; }


    public static Admin Create(string name) => new (name);

    public Admin WithName(string name)
    {
        Name = name;
        return this;
    }

    public Admin SetPassword(byte[] password, byte[] passwordKey)
    {
        Password = password;
        PasswordKey = passwordKey;
        return this;
    }
}

public class AdminConfiguration : DatabaseConfiguration<Admin, string>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .HasMaxLength(80);
    }
}