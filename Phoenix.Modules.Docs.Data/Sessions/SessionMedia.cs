namespace Phoenix.Modules.Docs.Data.Sessions;

public class SessionMedia : Entity
{
    private SessionMedia(string sessionId, string fileUrl)
    {
        SessionId = sessionId;
        FileUrl = fileUrl;
    }
    
    public string SessionId { get; private set; }
    public string FileUrl { get; private set; }
    public Session? Session { get; private set; }

    public static SessionMedia Create(string sessionId, string fileUrl) 
        => new (sessionId, fileUrl);
}

public class SessionMediaConfiguration : DatabaseConfiguration<SessionMedia, string>
{
    public override void Configure(EntityTypeBuilder<SessionMedia> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.SessionId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}