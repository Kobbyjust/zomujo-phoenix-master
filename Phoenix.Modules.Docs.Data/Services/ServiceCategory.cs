namespace Phoenix.Modules.Docs.Data.Services;

public class ServiceCategory : Entity
{
    private ServiceCategory(string key, string name)
    {
        Key = key;
        Name = name;
    }
    
    public string Key { get; private set; }
    public string Name { get; private set; }

    public static ServiceCategory Create(string key, string name) => new(key, name);
}

public class ServiceCategoryConfiguration : DatabaseConfiguration<ServiceCategory, string>
{
    public override void Configure(EntityTypeBuilder<ServiceCategory> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Key)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}