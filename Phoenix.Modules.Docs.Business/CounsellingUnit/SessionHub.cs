namespace Phoenix.Modules.Docs.Business.CounsellingUnit;

[Authorize]
public class SessionHub : Hub
{
    private readonly IStoreService _store;
    private readonly ILogger<SessionHub> _logger;

    private string UserId => Context.User?
        .FindFirst(JwtRegisteredClaimNames.NameId)?.Value ?? "";
    private bool IsCounsellor => Context.User?.FindFirst(ClaimTypes.Role)?.Value == "counsellor";
    private string? Role => Context.User?.FindFirst(ClaimTypes.Role)?.Value;
    private string? SessionIds => Context.GetHttpContext()?.Request.Headers["session-id"];
    private string ConnectionId => Context.ConnectionId;
    public SessionHub(IStoreService storeService, ILogger<SessionHub> logger)
    {
        _store = storeService;
        _logger = logger;
    }

    public async Task LoadRequests()
    {
        if (!IsCounsellor || !Connections.Counsellors.ContainsKey(UserId)) return;
        var requests = await _store.FetchSessions(false);
        await Clients.Client(Connections.Counsellors[UserId]).SendAsync(ClientMethods.LoadRequests, requests);
    }
    
    public override Task OnConnectedAsync()
    {
        if (IsCounsellor)
        {
            Connections.Counsellors.Remove(UserId);
            Connections.Counsellors.Add(UserId, ConnectionId);
            _store.InitiateCounsellorLogin(UserId).GetAwaiter();
        }
        else
        {
            Connections.Users.Remove(UserId);
            Connections.Users.Add(UserId, ConnectionId);
        }

        _logger.LogInformation("{Role} with id: {UserId} connected to session hub", 
            Role.Humanize(LetterCasing.Sentence), UserId);

        AddConnectedToSessions();

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Connections.Users.Remove(UserId);
        var isCounsellorRemoved = Connections.Counsellors.Remove(UserId);
        if (isCounsellorRemoved) _store.InitiateCounsellorLogout(UserId).GetAwaiter();
        return base.OnDisconnectedAsync(exception);
    }

    private void AddConnectedToSessions()
    {
        if (string.IsNullOrEmpty(SessionIds)) return;
        var sessions = JsonSerializer.Deserialize<string[]>(SessionIds) ?? new string[]{};
        foreach (var session in sessions)
        {
            var isValidSession = Connections.Sessions.TryGetValue(session, out var ids);
            if (!isValidSession) return;
            if (IsCounsellor)
                Connections.Sessions[session] = (ids.Item1, UserId);
            else
                Connections.Sessions[session] = (UserId, ids.Item2);
        }
    }
}

internal static class ClientMethods
{
    internal const string Message = "message";
    internal const string Connection = "connection";
    internal const string UserAbsent = "user_absent";
    internal const string UserTyping = "user_typing";
    internal const string EndSession = "end_counsel";
    internal const string UserPresent = "user_present";
    internal const string LeaveSession = "leave_meeting";
    internal const string LoadRequests = "load_requests";
    internal const string ResumeSession = "resume_counsel";
    internal const string ReviewSession = "review_counsel";
    internal const string CancelSession = "cancel_session";
    internal const string ReloadMessages = "reload_messages";
    internal const string ScheduleSession = "schedule_counsel";
    internal const string RequestSession = "request_counsellor";
    internal const string CounsellorTyping = "counsellor_typing";
    internal const string CounsellorAbsent = "counsellor_absent";
    internal const string SubscribeToTopic = "subscribe_to_topic";
    internal const string AcceptSessionRequest = "accept_request";
    internal const string CounsellorPresent = "counsellor_present";
    internal const string TransactionRequest = "transaction_request"; // TODO:: Notify frontend guys of value change
}

internal static class Connections
{
    internal static Dictionary<string, string> Users = new();
    internal static Dictionary<string, string> Counsellors = new();
    
    /// <summary>
    /// Holds session id as key and a tuple containing user id and counsellor id respectively as value
    /// </summary>
    internal static Dictionary<string, (string, string?)> Sessions = new();
}