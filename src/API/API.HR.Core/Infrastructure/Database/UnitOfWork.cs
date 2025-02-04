using Common.Core._08.Interface;

namespace API.HR.Core.Infrastructure.Database;

public class UnitOfWork(HRAppDbContext dbContext) : IUnitOfWork
{
    private readonly HRAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
