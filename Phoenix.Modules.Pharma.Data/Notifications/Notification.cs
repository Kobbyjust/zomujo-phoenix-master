using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Notifications;

public class PharmaNotification : Entity
{
    private PharmaNotification(string body, string type)
    {
        Body = body;
        Type = type;
    }
    
    public DateTime? ReadAt { get; set; }
    public string Body { get; set; }
    public string Type { get; set; } // TODO:: make enum
    public bool IsRead { get; set; }

    public static PharmaNotification Create(string body, string type) => new(body, type);

    public PharmaNotification HasDetails(string body, string type)
    {
        Body = body;
        Type = type;
        return this;
    }

    public PharmaNotification Read()
    {
        IsRead = true;
        ReadAt = DateTime.UtcNow;
        return this;
    }
}

public class NotificationConfiguration : DatabaseConfiguration<PharmaNotification, string>
{
    public override void Configure(EntityTypeBuilder<PharmaNotification> builder)
    {
        base.Configure(builder);
        builder.ToTable("PharmaNotifications");
    }
}