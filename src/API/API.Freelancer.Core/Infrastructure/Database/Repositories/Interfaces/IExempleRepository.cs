using API.Freelancer.Core.Feature.Domain.Exemple;
using API.Freelancer.Core.Feature.Domain.Exemple.Models;
using API.Freelancer.Core.Feature.Exemple.Queries.GetPaginate;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.Freelancer.Core.Infrastructure.Database.Repositories.Interfaces;

public interface IExempleRepository : IBaseRepository<ExempleEntity>
{
    Task<List<ExempleQueryModel>> GetAllAsync();
    Task<List<ExempleQueryModel>> GetPaginatedItemsAsync(GetPaginateExempleQuery query);
    Task<int> GetTotalCountAsync(GetPaginateExempleQuery query);
    Task<bool> ExistsByEmailAsync(Email email);
    Task<ExempleQueryModel> GetByIdAsync(Guid id);
}
