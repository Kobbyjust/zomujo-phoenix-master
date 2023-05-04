namespace Phoenix.Modules.Docs.Data.Payments;

public sealed class DocsPayment : Entity
{
    private DocsPayment(string userId, string amount, string reference)
    {
        UserId = userId;
        Amount = amount;
        Reference = reference;
    }
    
    public string UserId { get; private set; }
    public string Amount { get; private set; }
    public string Reference { get; private set; }
    public bool IsPaid { get; private set; }
    // add field for what exactly they are paying for

    public static DocsPayment Create(string userId, string amount, string reference) => new(userId, amount, reference);

    public DocsPayment HasPaid()
    {
        IsPaid = true;
        return this;
    }
}

public class PaymentConfiguration : DatabaseConfiguration<DocsPayment, string>
{
    public override void Configure(EntityTypeBuilder<DocsPayment> builder)
    {
        base.Configure(builder);
        builder.ToTable("DocsPayments");
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}