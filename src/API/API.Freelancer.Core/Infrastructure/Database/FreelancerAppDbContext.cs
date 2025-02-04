using API.Freelancer.Core.Feature.Domain;
using API.Freelancer.Core.Feature.Domain.Exemple;
using API.Freelancer.Core.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Freelancer.Core.Infrastructure.Database;

/// <summary>
/// Represents the database context for the Exemple application.
/// Provides access to database entities and configurations.
/// </summary>
public class FreelancerAppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FreelancerAppDbContext"/> class.
    /// Default constructor required for design-time tools.
    /// </summary>
    public FreelancerAppDbContext()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FreelancerAppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public FreelancerAppDbContext(DbContextOptions<FreelancerAppDbContext> options) : base(options)
    { }

    /// <summary>
    /// Gets or sets the database set for Exemple entities.
    /// </summary>
    public virtual DbSet<ExempleEntity> Exemple { get; set; }

    public DbSet<API.Freelancer.Core.Feature.Domain.Freelancer> Freelancers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<API.Freelancer.Core.Feature.Domain.Task> Tasks { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    /// <summary>
    /// Configures the entity models and applies configurations when the database schema is created.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity models.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExempleConfiguration());

        modelBuilder.ApplyConfiguration(new FreelancerMap());
        modelBuilder.ApplyConfiguration(new ClientMap());
        modelBuilder.ApplyConfiguration(new ProjectMap());
        modelBuilder.ApplyConfiguration(new ContractMap());
        modelBuilder.ApplyConfiguration(new PaymentMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
        modelBuilder.ApplyConfiguration(new SkillMap());
        modelBuilder.ApplyConfiguration(new InvoiceMap());
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
