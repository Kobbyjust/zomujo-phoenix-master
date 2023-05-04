using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Modules.Pharma.Data.Drugs;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Orders;

// TODO:: Make this an aggregate
public class Order : Entity
{
    private Order(string userId, string reviewId)
    {
        UserId = userId;
    }
    
    public string UserId { get; private set; }
    public string ReviewId { get; private set; }
    public string? PaymentId { get; private set; }
    public string? Number { get; private set; }
    public string ProcessInfoId { get; private set; }
    public ProcessInfo ProcessInfo { get; private set; }
    public string DispatchInfoId { get; private set; }
    public DispatchInfo? DispatchInfo { get; private set; }

    private IReadOnlyList<Drug> _drugs = new List<Drug>();
    public IEnumerable<Drug> Drugs => _drugs.AsQueryable();

    public static Order Create(string userId, string reviewId) => new(userId, reviewId);

    public Order WithPayment(string paymentId)
    {
        PaymentId = paymentId;
        return this;
    }
    
    public Order WithProcessInfo(string info)
    {
        ProcessInfoId = info;
        return this;
    }
    
    public Order WithDispatchInfo(string info)
    {
        DispatchInfoId = info;
        return this;
    }
}

public class OrderConfiguration : DatabaseConfiguration<Order, string>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
    }
}