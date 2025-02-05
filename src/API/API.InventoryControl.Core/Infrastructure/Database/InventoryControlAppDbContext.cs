using API.Exemple1.Core._08.Feature.Domain;
using API.Exemple1.Core._08.Infrastructure.Database.Mappings;
using API.InventoryControl.Core.Feature.Domain.Exemple;
using API.InventoryControl.Core.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.InventoryControl.Core.Infrastructure.Database;

/// <summary>
/// Represents the database context for the Exemple application.
/// Provides access to database entities and configurations.
/// </summary>
public class InventoryControlAppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryControlAppDbContext"/> class.
    /// Default constructor required for design-time tools.
    /// </summary>
    public InventoryControlAppDbContext()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryControlAppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public InventoryControlAppDbContext(DbContextOptions<InventoryControlAppDbContext> options) : base(options)
    { }

    /// <summary>
    /// Gets or sets the database set for Exemple entities.
    /// </summary>
    public virtual DbSet<ExempleEntity> Exemple { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }

    /// <summary>
    /// Configures the entity models and applies configurations when the database schema is created.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity models.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExempleConfiguration());

        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
        modelBuilder.ApplyConfiguration(new StockMovementConfiguration());

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
