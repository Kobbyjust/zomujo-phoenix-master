using Microsoft.EntityFrameworkCore;
using Phoenix.Modules.Auth.Data.Users;
using Phoenix.Shared.Persistence;
using Phoenix.Shared.Persistence.BoxMessages;

namespace Phoenix.Modules.Auth.Data.DataContext;

public class AuthDbContext : DbContext
{
    public AuthDbContext() { }
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Counsellor> Counsellors { get; set; }
    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<OutboxMessage> AuthOutbox { get; set; }
    public DbSet<InboxMessage> AuthInbox { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConnectionStrings.Development);
        }
    }
}