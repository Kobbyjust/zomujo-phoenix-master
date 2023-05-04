namespace Phoenix.Modules.MentalHealthTools.Data.QuoteCategory;

public class CategoryConfiguration : DatabaseConfiguration<QuoteCategory, string>
{
    public override void Configure(EntityTypeBuilder<global::Phoenix.Modules.MentalHealthTools.Data.QuoteCategory.QuoteCategory> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(70);
    }
}