using Phoenix.Modules.Docs.Data.Consultations;
using Phoenix.Modules.Docs.Data.Prescriptions;
using Phoenix.Modules.Docs.Data.Questioning;

namespace Phoenix.Modules.Docs.Data.Reviews;

public class Review : Entity
{
    private Review(string questionnaireId, string doctorId, string consultationId)
    {
        QuestionnaireId = questionnaireId;
        DoctorId = doctorId;
        ConsultationId = consultationId;
    }
    
    public string QuestionnaireId { get; private set; }
    public Questionnaire? Questionnaire { get; private set; }
    public string DoctorId { get; private set; }
    public string Diagnosis { get; private set; } = "";
    public string ConsultationId { get; private set; }
    public Consultation? Consultation { get; private set; }
    
    private List<Prescription> _prescriptions = new();
    public IEnumerable<Prescription> Prescriptions => _prescriptions.AsQueryable();

    public bool IsOrdered { get; private set; }

    public static Review Create(string questionnaireId, string doctorId, string consultationId) =>
        new(questionnaireId, doctorId, consultationId);

    public Review WithDiagnosis(string diagnosis)
    {
        Diagnosis = diagnosis;
        return this;
    }
}

public class ReviewConfiguration : DatabaseConfiguration<Review, string>
{
    public override void Configure(EntityTypeBuilder<Review> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.QuestionnaireId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.DoctorId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.ConsultationId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}