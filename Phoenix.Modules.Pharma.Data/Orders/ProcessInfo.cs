using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Orders;

public class ProcessInfo : Entity
{
    private ProcessInfo(string pharmaId)
    {
        PharmaId = pharmaId;
    }
    
    public bool IsFulfilled { get; private set; }
    public bool IsProcessed { get; private set; }
    public string PharmaId { get; private set; }
    public DateTime? AcceptedAt { get; private set; }
    public DateTime? ProcessedAt { get; private set; }
    public DateTime? FulfilledAt { get; private set; }

    public static ProcessInfo Create(string pharmaId) => new(pharmaId);
}

public class ProcessInfoConfiguration : DatabaseConfiguration<ProcessInfo, string>
{
    
}