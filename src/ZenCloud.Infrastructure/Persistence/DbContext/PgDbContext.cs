using Microsoft.EntityFrameworkCore;
using ZenCloud.Domain.Entities;
using ZenCloud.Infrastructure.Persistence.Configurations;

namespace ZenCloud.Infrastructure.Persistence.DbContext;

public class PgDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public PgDbContext(DbContextOptions<PgDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<DatabaseEngine> DatabaseEngines { get; set; }
    public DbSet<DatabaseInstance> DatabaseInstances { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<EmailLog> EmailLogs { get; set; }
    public DbSet<WebhookConfiguration> WebhookConfigurations { get; set; }
    public DbSet<WebhookLog> WebhookLogs { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PlanConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
        modelBuilder.ApplyConfiguration(new DatabaseEngineConfiguration());
        modelBuilder.ApplyConfiguration(new DatabaseInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new EmailLogConfiguration());
        modelBuilder.ApplyConfiguration(new WebhookConfigurationConfiguration());
        modelBuilder.ApplyConfiguration(new WebhookLogConfiguration());
        modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
        modelBuilder.ApplyConfiguration(new ErrorLogConfiguration());
    }
}