using Data;
using Phoenix.Modules.Docs.Data.Consultations;
using Phoenix.Modules.Docs.Data.Issues;
using Phoenix.Modules.Docs.Data.Notifications;
using Phoenix.Modules.Docs.Data.Payments;
using Phoenix.Modules.Docs.Data.Prescriptions;
using Phoenix.Modules.Docs.Data.Questioning;
using Phoenix.Modules.Docs.Data.Reviews;
using Phoenix.Modules.Docs.Data.Services;
using Phoenix.Modules.Docs.Data.Sessions;
using Phoenix.Shared.Persistence.BoxMessages;

namespace Phoenix.Modules.Docs.Data;

public class DocsDbContext : DbContext
{
    public DocsDbContext() { }
    public DocsDbContext(DbContextOptions<DocsDbContext> options) : base(options) { }

    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<DocsIssue> Issues { get; set; }
    public DbSet<DocsNotification> Notifications { get; set; }
    public DbSet<DocsPayment> Payments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Questionnaire> Questionnaires { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionMedia> SessionMedium { get; set; }
    public DbSet<OutboxMessage> DocsOutbox { get; set; }
    public DbSet<InboxMessage> DocsInbox { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DocsDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConnectionStrings.Development);
        }
    }
}