using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Orders;

public class DispatchInfo : Entity
{
    private DispatchInfo(string courierId, string pickupCode)
    {
        CourierId = courierId;
        PickupCode = pickupCode;
    }
    
    public bool IsCollected { get; private set; }
    public bool IsDelivered { get; private set; }
    public string PickupCode { get; private set; }
    public string CourierId { get; private set; }
    public DateTime CollectedAt { get; private set; }
    public DateTime DeliveredAt { get; private set; }

    public static DispatchInfo Create(string orderId, string courierId, string pickupCode) =>
        new(courierId, pickupCode);
}

public class DispatchInfoConfiguration : DatabaseConfiguration<DispatchInfo, string>
{
    
}