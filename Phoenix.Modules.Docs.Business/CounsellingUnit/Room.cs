namespace Phoenix.Modules.Docs.Business.CounsellingUnit;

public class Room
{
    public string[] Questionnaire { get; set; }
    public string RoomId { get; set; }
    public bool Ended { get; set; }
    public string Creator { get; set; }
    public string RoomName { get; set; }
    public bool UserLeft { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Counsellor { get; set; }
    public DateTime? ScheduledTo { get; set; }
    public bool IsScheduled { get; set; }
    public bool UserPresent { get; set; }
    public string? LastMessage { get; set; }
    public string? LastMessageSender { get; set; }
    public bool CounsellorPresent { get; set; }
}