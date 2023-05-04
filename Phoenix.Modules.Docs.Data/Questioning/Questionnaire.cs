using Phoenix.Modules.Docs.Data.Payments;
using Phoenix.Modules.Docs.Data.Services;

namespace Phoenix.Modules.Docs.Data.Questioning;

public class Questionnaire : Entity
{
    private Questionnaire(string userId, string serviceId)
    {
        UserId = userId;
        ServiceId = serviceId;
    }
    
    public string UserId { get; private set; }
    public string ServiceId { get; private set; }
    public Service? Service { get; private set; }
    public string? PaymentId { get; private set; }
    public DocsPayment? Payment { get; private set; }

    private List<Answer> _answers = new();
    public IEnumerable<Answer> Answers => _answers.AsQueryable();

    
    public static Questionnaire Create(string userId, string serviceId) =>
        new(userId, serviceId);

    public Questionnaire WithPaymentId(string paymentId)
    {
        PaymentId = paymentId;
        return this;
    }
    
    public Questionnaire WithUserId(string userId)
    {
        UserId = userId;
        return this;
    }
    
    public Questionnaire WithServiceId(string serviceId)
    {
        ServiceId = serviceId;
        return this;
    }
}

public class QuestionnaireConfiguration : DatabaseConfiguration<Questionnaire, string>
{
    public override void Configure(EntityTypeBuilder<Questionnaire> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.ServiceId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.PaymentId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}