using Newtonsoft.Json;

namespace Phoenix.Modules.Docs.Data.Sessions;

public class Session : Entity
{
    private Session(string userId, string anonymousName)
    {
        UserId = userId;
        AnonymousName = anonymousName;
    }
    
    public string UserId { get; private set; }
    public string? CounsellorId { get; private set; }
    public bool IsAccepted { get; private set; }
    public bool InProgress { get; private set; }
    public string AnonymousName { get; private set; }
    public string? Feedback { get; private set; }
    public int? Rate { get; private set; }    
    
    // Will not need this with SignalR
    // public string RoomId { get; set; }
    public IEnumerable<Response>? Answers { get; private set; }

    public static Session Create(string userId, string anonymousName) =>
        new(userId, anonymousName);

    public Session WithUserId(string userId)
    {
        UserId = userId;
        return this;
    }

    public Session Accept(string? counsellorId)
    {
        if (string.IsNullOrEmpty(counsellorId)) return this;
        CounsellorId = counsellorId;
        IsAccepted = true;
        return this;
    }

    public Session WithFeedback(string? feedback)
    {
        Feedback = feedback;
        return this;
    }

    public Session WithAnswers(IEnumerable<Response>? answers)
    {
        Answers = answers;
        return this;
    }
}

public class Response
{
    public string Question { get; set; }
    public string Answer { get; set; }
}

public class SessionConfiguration : DatabaseConfiguration<Session, string>
{
    public override void Configure(EntityTypeBuilder<Session> builder)
    {
        base.Configure(builder);
        // This Converter will perform the conversion to and from Json to the desired type
        builder.Property(e => e.Answers).HasConversion(
            v => JsonConvert.SerializeObject(v,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
            v => JsonConvert.DeserializeObject<IEnumerable<Response>>(v,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
        
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.CounsellorId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.AnonymousName)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}