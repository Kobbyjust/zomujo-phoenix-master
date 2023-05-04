namespace Phoenix.Modules.Docs.Data.Questioning;

public class Faq : Entity
{
    private Faq(string questionId, string answerId)
    {
        QuestionId = questionId;
        AnswerId = answerId;
    }
    
    public string QuestionId { get; private set; }
    public Question? Question { get; private set; }
    public string AnswerId { get; private set; }
    public Answer? Answer { get; private set; }

    public static Faq Create(string questionId, string answerId) => new(questionId, answerId);
}

public class FaqConfiguration : DatabaseConfiguration<Faq, string>
{
    public override void Configure(EntityTypeBuilder<Faq> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.QuestionId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.AnswerId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}