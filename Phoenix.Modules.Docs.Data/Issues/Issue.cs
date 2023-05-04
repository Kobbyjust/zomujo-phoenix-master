namespace Phoenix.Modules.Docs.Data.Issues;

public class DocsIssue : Entity
{
    private DocsIssue(string userId, string type, string message)
    {
        UserId = userId;
        Type = type;
        Message = message;
    }
    public string UserId { get; private set; }
    public string Type { get; private set; } // TODO: make enum
    public string Message { get; private set; }

    public static DocsIssue Create(string userId, string type, string message) => new(userId, type, message);
}

public class IssueConfiguration : DatabaseConfiguration<DocsIssue, string>
{
    public override void Configure(EntityTypeBuilder<DocsIssue> builder)
    {
        base.Configure(builder);
        builder.ToTable("DocsIssues");
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}