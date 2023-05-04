using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Modules.Pharma.Data.Orders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Drugs;

public class Drug : Entity
{
    private Drug(string genericName, string tradeName, decimal price, int quantity)
    {
        GenericName = genericName;
        TradeName = tradeName;
        Price = price;
        Quantity = quantity;
    }
    
    public string? Comment { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string TradeName { get; private set; }
    public string GenericName { get; private set; }
    //public IEnumerable<string>? Suggestions { get; private set; }
    
    private IReadOnlyList<Order> _orders = new List<Order>();
    public IEnumerable<Order> Orders => _orders.AsQueryable();


    public static Drug Create(string genericName, string tradeName, decimal price, int quantity = 0) =>
        new(genericName, tradeName, price, quantity);

    public Drug HasComment(string? comment)
    {
        Comment = comment;
        return this;
    }

    public Drug Costs(decimal price)
    {
        Price = price;
        return this;
    }

    public Drug QuantityInStore(int quantity)
    {
        Quantity = quantity;
        return this;
    }

    public Drug WithName(string genericName, string tradeName)
    {
        GenericName = genericName;
        TradeName = tradeName;
        return this;
    }
}

public class DrugConfiguration : DatabaseConfiguration<Drug, string>
{
    public override void Configure(EntityTypeBuilder<Drug> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.TradeName)
            .HasColumnType("varchar")
            .HasMaxLength(50);
        builder.Property(x => x.GenericName)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}