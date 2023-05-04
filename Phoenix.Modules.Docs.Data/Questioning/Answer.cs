namespace Phoenix.Modules.Docs.Data.Questioning;

public class Answer : Entity
{
    private Answer(string questionId, string value)
    {
        QuestionId = questionId;
        Value = value;
    }
    
    public string Value { get; private set; }
    public string? MoreInfo { get; private set; }
    public string QuestionId { get; private set; }
    public Question? Question { get; private set; }

    public static Answer Create(string questionId, string value) => new(questionId, value);

    public Answer WithMoreInfo(string info)
    {
        MoreInfo = info;
        return this;
    }
}

public class AnswerConfiguration : DatabaseConfiguration<Answer, string>
{
    public override void Configure(EntityTypeBuilder<Answer> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.QuestionId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}