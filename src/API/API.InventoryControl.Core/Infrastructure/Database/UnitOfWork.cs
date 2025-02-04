using Common.Core._08.Interface;

namespace API.InventoryControl.Core.Infrastructure.Database;

public class UnitOfWork(InventoryControlAppDbContext dbContext) : IUnitOfWork
{
    private readonly InventoryControlAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
