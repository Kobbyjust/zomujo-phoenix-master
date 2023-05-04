namespace Phoenix.Shared.Persistence
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}