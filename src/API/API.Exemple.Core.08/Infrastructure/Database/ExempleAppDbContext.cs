using API.Exemple.Core._08.Feature.Domain.Exemple;
using API.Exemple.Core._08.Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace API.Exemple.Core._08.Infrastructure.Database;

public class ExempleAppDbContext : DbContext
{
    public ExempleAppDbContext()
    { }

    public ExempleAppDbContext(DbContextOptions<ExempleAppDbContext> options) : base(options)
    { }

    public virtual DbSet<ExempleEntity> Exemple { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExempleConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });
}
