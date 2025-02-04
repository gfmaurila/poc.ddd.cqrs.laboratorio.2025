using Common.Core._08.Interface;

namespace API.External.Person.Infrastructure.Database;

public class UnitOfWork(PersonAppDbContext dbContext) : IUnitOfWork
{
    private readonly PersonAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
