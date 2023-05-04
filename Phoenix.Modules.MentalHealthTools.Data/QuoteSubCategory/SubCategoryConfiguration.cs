namespace Phoenix.Modules.MentalHealthTools.Data.QuoteSubCategory;

public class SubCategoryConfiguration : DatabaseConfiguration<QuoteSubCategory, string>
{
    public override void Configure(EntityTypeBuilder<QuoteSubCategory> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(70);
    }
}