using API.HR.Core.Feature.Domain.Exemple;
using API.HR.Core.Feature.Domain.Exemple.Models;
using API.HR.Core.Feature.Exemple.Queries.GetPaginate;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.HR.Core.Infrastructure.Database.Repositories.Interfaces;

public interface IExempleRepository : IBaseRepository<ExempleEntity>
{
    Task<List<ExempleQueryModel>> GetAllAsync();
    Task<List<ExempleQueryModel>> GetPaginatedItemsAsync(GetPaginateExempleQuery query);
    Task<int> GetTotalCountAsync(GetPaginateExempleQuery query);
    Task<bool> ExistsByEmailAsync(Email email);
    Task<ExempleQueryModel> GetByIdAsync(Guid id);
}
