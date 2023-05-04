namespace Phoenix.Shared.Persistence.Messaging;

public static class Messaging
{
    public class Keys
    {
        public const string AuthOutbox = "Events:Auth:Outbox";
        public const string DocsOutbox = "Events:Docs:Outbox";
        public const string MhToolsOutbox = "Events:MHTools:Outbox";
        public const string PharmaOutbox = "Events:Pharma:Outbox";
    }
}