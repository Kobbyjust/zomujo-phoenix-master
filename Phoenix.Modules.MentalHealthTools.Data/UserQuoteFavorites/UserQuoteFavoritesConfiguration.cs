namespace Phoenix.Modules.MentalHealthTools.Data.UserQuoteFavorites;

public class UserQuoteFavoritesConfiguration : DatabaseConfiguration<UserQuoteFavorites, string>
{
    public override void Configure(EntityTypeBuilder<UserQuoteFavorites> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasMaxLength(70);
    }
}