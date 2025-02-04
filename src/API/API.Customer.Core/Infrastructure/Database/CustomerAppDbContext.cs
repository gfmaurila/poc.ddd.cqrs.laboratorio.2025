using API.Customer.Core.Feature.Domain;
using API.Customer.Core.Feature.Domain.Exemple;
using API.Customer.Core.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Customer.Core.Infrastructure.Database;

/// <summary>
/// Represents the database context for the Exemple application.
/// Provides access to database entities and configurations.
/// </summary>
public class CustomerAppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerAppDbContext"/> class.
    /// Default constructor required for design-time tools.
    /// </summary>
    public CustomerAppDbContext()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerAppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public CustomerAppDbContext(DbContextOptions<CustomerAppDbContext> options) : base(options)
    { }

    /// <summary>
    /// Gets or sets the database set for Exemple entities.
    /// </summary>
    public virtual DbSet<ExempleEntity> Exemple { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountSubscription> AccountSubscriptions { get; set; }
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    public DbSet<MessageUsage> MessageUsages { get; set; }
    public DbSet<MessageUsageItem> MessageUsageItems { get; set; }
    public DbSet<AccountProduct> AccountProducts { get; set; }

    /// <summary>
    /// Configures the entity models and applies configurations when the database schema is created.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity models.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExempleConfiguration());

        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new AccountSubscriptionConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionPlanConfiguration());
        modelBuilder.ApplyConfiguration(new MessageUsageConfiguration());
        modelBuilder.ApplyConfiguration(new MessageUsageItemConfiguration());
        modelBuilder.ApplyConfiguration(new AccountProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Configures the database options, including logging settings.
    /// </summary>
    /// <param name="optionsBuilder">The options builder used to configure the database context.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    /// <summary>
    /// Logger factory for debugging database queries.
    /// </summary>
    public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });
}
