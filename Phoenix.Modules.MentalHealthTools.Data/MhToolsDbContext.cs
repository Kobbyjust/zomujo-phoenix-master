using Phoenix.Shared.Persistence.BoxMessages;

namespace Phoenix.Modules.MentalHealthTools.Data;

public class MhToolsDbContext : DbContext
{
    public MhToolsDbContext() { }
    public MhToolsDbContext(DbContextOptions<MhToolsDbContext> options) : base(options) { }

    public DbSet<QuoteCategory.QuoteCategory> Categories { get; set; }
    public DbSet<QuoteSubCategory.QuoteSubCategory> SubCategories { get; set; }
    public DbSet<Quotes.Quotes> Quotes { get; set; }
    public DbSet<UserQuoteFavorites.UserQuoteFavorites> UserQuoteFavorites { get; set; }
    public DbSet<OutboxMessage> MHToolsOutbox { get; set; }
    public DbSet<InboxMessage> MHToolsInbox { get; set; }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MhToolsDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConnectionStrings.Development);
        }
    }
}