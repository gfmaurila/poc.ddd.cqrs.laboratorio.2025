using Common.Core._08.Interface;

namespace API.Clinic.Core.Infrastructure.Database;

public class UnitOfWork(ClinicAppDbContext dbContext) : IUnitOfWork
{
    private readonly ClinicAppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
