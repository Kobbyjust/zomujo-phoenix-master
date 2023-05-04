using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Issues;

public class PharmaIssue : Entity
{
    private PharmaIssue(string userId, string type, string message)
    {
        UserId = userId;
        Type = type;
        Message = message;
    }
    public string UserId { get; private set; }
    public string Type { get; private set; } // TODO: make enum
    public string Message { get; private set; }

    public static PharmaIssue Create(string userId, string type, string message) => new(userId, type, message);
}

public class IssueConfiguration : DatabaseConfiguration<PharmaIssue, string>
{
    public override void Configure(EntityTypeBuilder<PharmaIssue> builder)
    {
        base.Configure(builder);
        builder.ToTable("PharmaIssues");
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}