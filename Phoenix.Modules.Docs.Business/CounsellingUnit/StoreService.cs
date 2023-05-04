using System.Globalization;
using System.Text.Json;
using Bogus;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Phoenix.Modules.Docs.Business.CounsellingUnit;

internal enum Rooms
{
    RoomGeneral = 1,
    RoomSuicideIdeation
}

internal class StoreService : IStoreService
{
    private readonly IDatabase _database;
    private readonly ILogger<StoreService> _logger;
    private const string Rooms = "mental-health:sessions"; // hashset
    private static string CounsellorLoginKey => "mental-health:counsellor:stats";
    private static string CounsellorLogin(string counsellorId) 
        => $"{CounsellorLoginKey}:counsellor_login_{counsellorId}"; // strings
    private static string Messages(string roomId) => $"mental-health:messages:{roomId}"; // list

    public StoreService(IDatabase database, ILogger<StoreService> logger)
    {
        _database = database;
        _logger = logger;
    }
    
    public async Task<Room?> GetSessionData(string roomId)
    {
        var sessions = await FetchSessions();
        return sessions.FirstOrDefault(x => x.RoomId == roomId);
    }

    public async Task AddMessageToPool<TPayload>(Message<TPayload> message, string roomId)
        where TPayload : IMessage
    {
        await _database.ListRightPushAsync(Messages(roomId), JsonSerializer.Serialize(message));
    }

    // TODO:: Potential malfunction here if redis values have messages of variable payloads
    public async Task<IEnumerable<Message<TPayload>>> GetMessagesFromPool<TPayload>(string roomId)
        where TPayload : IMessage
    {
        var values = await _database.ListRangeAsync(Messages(roomId));
        var messages = new List<Message<TPayload>>();
        
        foreach (var redisValue in values)
        {
            if (redisValue.IsNull) continue;
            messages.Add(JsonSerializer.Deserialize<Message<TPayload>>(redisValue!)!);
        }

        return messages;
    }

    public async Task<Room?> CreateSession(SessionRequest request, string roomId)
    {
        var sessions = await FetchSessions(false);
        if (sessions.Any(x => x.Creator == request.AnonymousName && !x.Ended)) return null;
        var session = new Room
        {
            RoomId = roomId,
            RoomName = GenerateRoom(),
            Questionnaire = request.Questionnaire,
            Creator = request.AnonymousName,
            CreatedAt = DateTime.UtcNow
        };

        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
        // there is an operation being done here in incognito system check and see if necessary to do here
        return session;
    }

    public async Task AcceptRequest(string roomId, string counsellorId)
    {
        var sessions = await FetchSessions();
        var session = sessions
            .FirstOrDefault(x => x.RoomId == roomId && string.IsNullOrEmpty(x.Counsellor));
        if (session is null) return;

        session.Counsellor = counsellorId;
        await _database.HashSetAsync(Rooms, new []
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task<bool> IsRoomReady(string roomId)
    {
        var sessions = await FetchSessions();
        return sessions.Any(x => x.RoomId == roomId && !x.Ended);
    }

    public async Task MarkCounsellorRead(string roomId) => await MarkMessagesRead(roomId);

    public async Task MarkUserRead(string roomId) => await MarkMessagesRead(roomId, false);

    public async Task<IEnumerable<Room>> FetchSessions(bool withMessages = true)
    {
        var entries = await _database.HashGetAllAsync(Rooms);
        var sessions = new List<Room>();
        
        foreach (var hashEntry in entries)
        {
            var value = hashEntry.Value.ToString();
            if(string.IsNullOrEmpty(value)) continue;
            var room = JsonSerializer.Deserialize<Room>(value);
            
            if(room is null || room.Ended || DateTime.UtcNow - room.CreatedAt > TimeSpan.FromMinutes(5))
                continue;

            if (!string.IsNullOrEmpty(room.Counsellor) && withMessages)
            {
                var messages = (await GetMessagesFromPool<MessageSendMessage>(room.RoomId))
                    .ToList();
                if (messages.Any())
                {
                    var lastMessage = messages.LastOrDefault();
                    if (lastMessage?.Payload != null)
                    {
                        room.LastMessage = string.IsNullOrEmpty(lastMessage?.Payload.Text)
                            ? $"{lastMessage?.Payload.File?.Type}"
                            : lastMessage?.Payload.Text;
                        room.LastMessageSender = lastMessage?.Username;
                    }
                }
            }
            
            sessions.Add(room);
        }

        return sessions;
    }

    public async Task EndSession(string roomId)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;

        session.Ended = true;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task UpdateUserPresence(string roomId, bool isPresent)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;

        await MarkMessagesRead(roomId, false);
        session.UserPresent = true;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task UpdateCounsellorPresence(string roomId, bool isPresent)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;

        await MarkMessagesRead(roomId, false);
        session.CounsellorPresent = true;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task ScheduleCounsel(string roomId, DateTime scheduledTo)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;
        session.IsScheduled = true;
        session.ScheduledTo = scheduledTo;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task ResumeCounsel(string roomId)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;
        session.IsScheduled = false;
        session.ScheduledTo = null;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task LeaveSession(string roomId)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;
        session.Ended = true;
        session.UserLeft = true;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });    
    }

    public async Task CancelSession(string roomId)
    {
        var sessions = await FetchSessions(false);
        var session = sessions.FirstOrDefault(x => x.RoomId == roomId);
        if (session is null) return;
        session.Ended = true;
        session.UserLeft = true;
        await _database.HashSetAsync(Rooms, new[]
        {
            new HashEntry(roomId, JsonSerializer.Serialize(session))
        });
    }

    public async Task FlushDb()
    {
        throw new NotImplementedException();
    }

    public async Task InitiateCounsellorLogin(string counsellorId)
    {
        await _database.StringSetAsync(CounsellorLogin(counsellorId), 
            DateTime.UtcNow.ToString(CultureInfo.CurrentCulture));
    }

    public async Task InitiateCounsellorLogout(string counsellorId)
    {
        var loginTime = await _database.StringGetAsync(CounsellorLogin(counsellorId));
        if (loginTime.IsNull) return;

        var stats = new CounsellorStat(counsellorId, 
            DateTime.Parse(loginTime!), 
            DateTime.UtcNow);

        await _database.StringSetAsync(CounsellorLogin(counsellorId),
            JsonSerializer.Serialize(stats));
    }

    public async Task<IEnumerable<CounsellorStat>?> GetCounsellorStats()
    {
        var values = await _database.HashGetAllAsync(CounsellorLoginKey);
        if (values.Length == 0) return null;

        var stats = new List<CounsellorStat>();
        foreach (var hashEntry in values)
        {
            var stat = JsonSerializer.Deserialize<CounsellorStat>(hashEntry.Value.ToString());
            if (stat is not null) stats.Add(stat);
        }

        return stats;
    }

    public async Task ClearCounsellorStats() 
        => await _database.KeyDeleteAsync(CounsellorLoginKey);

    private async Task MarkMessagesRead(string roomId, bool byCounsellor = true)
    {
        var values = (await GetMessagesFromPool<MessageSendMessage>(roomId)).ToList();
        
        // have to loop through all values cause we are updating redis value by index
        for (var i = 0; i < values.Count; i++)
        {
            var message = values![i];
            if (byCounsellor) message.CounsellorRead = true;
            message.UserRead = true;

            await _database.ListSetByIndexAsync(Messages(roomId), i,
                JsonSerializer.Serialize(message));
        }
    }
    
    private static string GenerateRoom() => new Faker().Lorem.Slug(9);
}

public interface IStoreService
{
    Task<Room?> GetSessionData(string roomId);

    Task AddMessageToPool<TPayload>(Message<TPayload> message, string roomId)
        where TPayload : IMessage;
    Task<IEnumerable<Message<TPayload>>> GetMessagesFromPool<TPayload>(string roomId)
        where TPayload : IMessage;
    Task<Room?> CreateSession(SessionRequest request, string roomId);
    Task AcceptRequest(string roomId, string counsellorId);
    Task<bool> IsRoomReady(string roomId);
    Task MarkCounsellorRead(string roomId);
    Task MarkUserRead(string roomId);
    Task<IEnumerable<Room>> FetchSessions(bool withMessages = true);
    Task EndSession(string roomId);
    Task UpdateUserPresence(string roomId, bool isPresent);
    Task UpdateCounsellorPresence(string roomId, bool isPresent);
    Task ScheduleCounsel(string roomId, DateTime scheduledTo); // TODO:: check type of scheduledTo
    Task ResumeCounsel(string roomId);
    Task LeaveSession(string roomId);
    Task CancelSession(string roomId);
    Task FlushDb();
    Task InitiateCounsellorLogin(string counsellorId);
    Task InitiateCounsellorLogout(string counsellorId);
    Task<IEnumerable<CounsellorStat>?> GetCounsellorStats();
    Task ClearCounsellorStats();
}

public class Message<T> where T : IMessage
{
    public Message(string username)
    {
        Username = username;
        if (typeof(T) == typeof(MessageSendMessage)) Type = MessageType.SendMessage;
        if (typeof(T) == typeof(MessageJoinRoom)) Type = MessageType.JoinRoom;
        if (typeof(T) == typeof(MessageError)) Type = MessageType.Error;
    }
    
    public Guid Id { get; } = Guid.NewGuid();
    public MessageType Type { get; private set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public bool UserRead { get; set; }
    public bool CounsellorRead { get; set; }
    public T? Payload { get; set; }
}

public interface IMessage{}

internal record MessageError(string Error) : IMessage;
internal record MessageSendMessage(string Text, string RoomId, ReplyData? ReplyTo, FileData? File) : IMessage;
internal record MessageReferral(string ReferredAt, string ReferredTo) : IMessage;
internal record MessageJoinRoom(string RoomId) : IMessage;

internal record FileData(string Type, string UrlPath, string Duration, string LocalPath);
internal record ReplyData(string Id, string Text, string Username);

public record CounsellorStat(string CounsellorId, DateTime LoginTime, DateTime LogoutTime);

public enum MessageType
{
    Error,
    JoinRoom,
    CreateRoom,
    SetUsername,
    SendMessage,
    AcceptRequest,
}