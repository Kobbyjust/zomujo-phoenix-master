namespace Phoenix.Modules.MentalHealthTools.Data.Quotes;

public class QuotesConfiguration : DatabaseConfiguration<Quotes, string>
{
    public override void Configure(EntityTypeBuilder<Quotes> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Author)
            .HasColumnType("varchar")
            .HasMaxLength(70);
        builder.Property(x => x.Quote)
            .HasMaxLength(300);
    }
}