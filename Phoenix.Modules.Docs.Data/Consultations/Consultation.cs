namespace Phoenix.Modules.Docs.Data.Consultations;

public class Consultation : Entity
{
    private Consultation(string userId, string doctorId)
    {
        UserId = userId;
        DoctorId = doctorId;
    }
    
    public string UserId { get; private set; }
    public string DoctorId { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsPaid { get; private set; }
    public string Reference { get; private set; }

    public static Consultation Create(string userId, string doctorId) => new(userId, doctorId);

    public Consultation WithCost(decimal amount)
    {
        Amount = amount;
        return this;
    }

    public Consultation HasPaid()
    {
        IsPaid = true;
        return this;
    }

    public Consultation HasReference(string reference)
    {
        Reference = reference;
        return this;
    }
}

public class ConsultationConfiguration : DatabaseConfiguration<Consultation, string>
{
    public override void Configure(EntityTypeBuilder<Consultation> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(40);
        builder.Property(x => x.DoctorId)
            .HasColumnType("varchar")
            .HasMaxLength(40);
    }
}