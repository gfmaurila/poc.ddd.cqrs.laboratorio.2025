using API.Auth.Feature.Modelo.Domain.Events;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Auth.Infrastructure.Database;

public class ModeloAppDbContext : DbContext
{
    public ModeloAppDbContext(DbContextOptions<ModeloAppDbContext> options)
        : base(options) { }

    public DbSet<ModeloEntity> Modelo { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply Fluent API configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Optional: Add additional configurations if required

        base.OnModelCreating(modelBuilder);
    }

}
