namespace Phoenix.Modules.Docs.Data.Prescriptions;

public sealed class Prescription : Entity
{
    private Prescription(string userId, string doctorId, string name)
    {
        UserId = userId;
        DoctorId = doctorId;
        Name = name;
    }
    
    public string UserId { get; set; }
    public string DoctorId { get; set; }
    public string Name { get; set; }
    public string? MoreInfo { get; set; }
    
    /// <summary>
    /// Has ids of prescribed drugs
    /// </summary>
    public IEnumerable<Drug>? Drugs { get; set; }

    public static Prescription Create(string userId, string doctorId, string name) => new(userId, doctorId, name);

    public Prescription WithMoreInfo(string? info)
    {
        MoreInfo = info;
        return this;
    }

    public Prescription WithDrugs(IEnumerable<Drug>? drugs)
    {
        Drugs = drugs;
        return this;
    }
    
}

public class Drug : ValueObject
{
    public string Name { get; set; }
}

public class PrescriptionConfiguration : DatabaseConfiguration<Prescription, string>
{
    public override void Configure(EntityTypeBuilder<Prescription> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.DoctorId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(70);
        builder.OwnsMany(x => x.Drugs);
    }
}