using Phoenix.Modules.Docs.Data.Sessions;

namespace Phoenix.Modules.Docs.Business.CounsellingUnit;

public class SessionRequest
{
    public string AnonymousName { get; set; }
    public string[] Questionnaire { get; set; }
    public string Token { get; set; }
    public string MessagingToken { get; set; }
}

internal class SessionResponse
{
    public string Id { get; set; }
    public string AnonymousName { get; set; }
    public IEnumerable<Response> Answers { get; set; }
}

internal class SessionPageResponse
{
    public string Id { get; set; }
    public string AnonymousName { get; set; }
}