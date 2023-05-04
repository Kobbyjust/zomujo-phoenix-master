namespace Phoenix.Modules.Docs.Data.Notifications;

public sealed class DocsNotification : Entity
{
    private DocsNotification(string body, string type)
    {
        Body = body;
        Type = type;
    }
    
    public DateTime? ReadAt { get; set; }
    public string Body { get; set; }
    public string Type { get; set; } // TODO:: make enum
    public bool IsRead { get; set; }

    public static DocsNotification Create(string body, string type) => new(body, type);

    public DocsNotification HasDetails(string body, string type)
    {
        Body = body;
        Type = type;
        return this;
    }

    public DocsNotification Read()
    {
        IsRead = true;
        ReadAt = DateTime.UtcNow;
        return this;
    }
}

public class NotificationConfiguration : DatabaseConfiguration<DocsNotification, string>
{
    public override void Configure(EntityTypeBuilder<DocsNotification> builder)
    {
        base.Configure(builder);
        builder.ToTable("DocsNotifications");
    }
}