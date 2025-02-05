using API.External.Person.Feature.Domain.Exemple;
using API.External.Person.Feature.Domain.Exemple.Models;
using API.External.Person.Feature.Exemple.Queries.GetPaginate;
using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain.ValueObjects;

namespace API.External.Person.Infrastructure.Database.Repositories.Interfaces;

public interface IExempleRepository : IBaseRepository<ExempleEntity>
{
    Task<List<ExempleQueryModel>> GetAllAsync();
    Task<List<ExempleQueryModel>> GetPaginatedItemsAsync(GetPaginateExempleQuery query);
    Task<int> GetTotalCountAsync(GetPaginateExempleQuery query);
    Task<bool> ExistsByEmailAsync(Email email);
    Task<ExempleQueryModel> GetByIdAsync(Guid id);
}
