using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phoenix.Shared.Persistence;

namespace Phoenix.Modules.Pharma.Data.Payments;

public class Payment : Entity
{
    private Payment(string userId, string amount, string reference)
    {
        UserId = userId;
        Amount = amount;
        Reference = reference;
    }
    
    public string UserId { get; private set; }
    public string Amount { get; private set; }
    public string Reference { get; private set; }
    public bool IsPaid { get; private set; }

    public static Payment Create(string userId, string amount, string reference) => new(userId, amount, reference);

    public Payment HasPaid()
    {
        IsPaid = true;
        return this;
    }
}

public class PaymentConfiguration : DatabaseConfiguration<Payment, string>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);
        builder.ToTable("PharmaPayments");
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}