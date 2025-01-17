using API.Exemple.Core._08.Feature.Domain.Exemple;
using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;

public interface IExempleRepository : IBaseRepository<ExempleEntity>
{
    Task<List<ExempleQueryModel>> GetAllAsync();
    Task<bool> ExistsByEmailAsync(Email email);
    Task<ExempleQueryModel> GetByIdAsync(Guid id);
}
