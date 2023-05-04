using Data;
using Microsoft.EntityFrameworkCore;
using Phoenix.Modules.Pharma.Data.Drugs;
using Phoenix.Modules.Pharma.Data.Issues;
using Phoenix.Modules.Pharma.Data.Notifications;
using Phoenix.Modules.Pharma.Data.Orders;
using Phoenix.Modules.Pharma.Data.Payments;
using Phoenix.Shared.Persistence;
using Phoenix.Shared.Persistence.BoxMessages;

namespace Phoenix.Modules.Pharma.Data;

public class PharmaDbContext : DbContext
{
    public PharmaDbContext() { }
    public PharmaDbContext(DbContextOptions<PharmaDbContext> options) : base(options) { }

    public DbSet<Drug> Drugs { get; set; }
    public DbSet<PharmaIssue> Issues { get; set; }
    public DbSet<PharmaNotification> Notifications { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<DispatchInfo> DispatchInfos { get; set; }
    public DbSet<ProcessInfo> ProcessInfos { get; set; }
    public DbSet<OutboxMessage> PharmaOutbox { get; set; }
    public DbSet<InboxMessage> PharmaInbox { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(PharmaDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConnectionStrings.Development);
        }
    }
}