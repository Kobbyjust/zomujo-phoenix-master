using Phoenix.Modules.Docs.Data.Questioning;

namespace Phoenix.Modules.Docs.Data.Services;

public class Service : Entity
{
    private Service(string name, string? description)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; }
    public string? ServiceCategoryId { get; private set; }
    public ServiceCategory? ServiceCategory { get; private set; }
    public string? Description { get; private set; }
    public string? Key { get; private set; }
    
    private List<Question> _questions = new();
    public IEnumerable<Question> Questions => _questions.AsQueryable();

    private List<Faq> _faqs = new();
    public IEnumerable<Faq> Faqs => _faqs.AsQueryable();
    
    public static Service Create(string name, string? description) => new(name, description);
}

public class ServiceConfiguration : DatabaseConfiguration<Service, string>
{
    public override void Configure(EntityTypeBuilder<Service> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.ServiceCategoryId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}