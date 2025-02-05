using API.Clinic.Core.Feature.Domain.Exemple;
using API.Clinic.Core.Infrastructure.Database.Mappings;
using API.Exemple1.Core._08.Feature.Domain;
using API.Exemple1.Core._08.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Clinic.Core.Infrastructure.Database;

/// <summary>
/// Represents the database context for the Exemple application.
/// Provides access to database entities and configurations.
/// </summary>
public class ClinicAppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClinicAppDbContext"/> class.
    /// Default constructor required for design-time tools.
    /// </summary>
    public ClinicAppDbContext()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClinicAppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public ClinicAppDbContext(DbContextOptions<ClinicAppDbContext> options) : base(options)
    { }

    /// <summary>
    /// Gets or sets the database set for Exemple entities.
    /// </summary>
    public virtual DbSet<ExempleEntity> Exemple { get; set; }

    public DbSet<Person> Persons { get; set; }
    public DbSet<HealthcareProfessional> HealthcareProfessionals { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    /// <summary>
    /// Configures the entity models and applies configurations when the database schema is created.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity models.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExempleConfiguration());

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new HealthcareProfessionalConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new InventoryItemConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());

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
