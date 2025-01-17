using API.Exemple.Core._08.Feature.Domain.Exemple;
using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace API.Exemple.Core._08.Infrastructure.Database.Repositories;

public class ExempleRepository : BaseRepository<ExempleEntity>, IExempleRepository
{
    private readonly ExempleAppDbContext _context;
    public ExempleRepository(ExempleAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ExempleQueryModel>> GetAllAsync()
        => MapperModelToEntity(await _context.Exemple.AsNoTracking().ToListAsync());

    public async Task<bool> ExistsByEmailAsync(Email email)
        => await _context.Exemple.AsNoTracking().AnyAsync(entity => entity.Email.Address == email.Address);

    public async Task<ExempleQueryModel> GetByIdAsync(Guid id)
    {
        var entity = await _context.Exemple.AsNoTracking()
                                   .Where(u => u.Id == id)
                                   .FirstOrDefaultAsync();
        if (entity is not null)
            return MapperModelToEntity(entity);

        return null;
    }


    #region Private
    private List<ExempleQueryModel> MapperModelToEntity(List<ExempleEntity> entity)
    {
        var model = new List<ExempleQueryModel>();
        foreach (var entityItem in entity)
        {
            model.Add(new ExempleQueryModel
            {
                Id = entityItem.Id,
                FirstName = entityItem.FirstName,
                LastName = entityItem.LastName,
                Gender = entityItem.Gender,
                Email = entityItem.Email.Address,
                Phone = entityItem.Phone.Phone,
                Role = entityItem.Role
            });
        }
        return model;
    }

    private ExempleQueryModel MapperModelToEntity(ExempleEntity entity)
    {

        return new ExempleQueryModel()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Gender = entity.Gender,
            Email = entity.Email.Address,
            Phone = entity.Phone.Phone,
            Role = entity.Role
        };
    }
    #endregion

}
