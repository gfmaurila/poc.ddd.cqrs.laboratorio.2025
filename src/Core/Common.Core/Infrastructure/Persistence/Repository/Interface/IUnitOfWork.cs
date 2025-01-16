namespace Common.Core.Infrastructure.Persistence.Repository.Interface;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
