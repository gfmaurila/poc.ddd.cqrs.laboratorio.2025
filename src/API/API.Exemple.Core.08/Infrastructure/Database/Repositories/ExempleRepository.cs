using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using API.Exemple.Core._08.Infrastructure.Domain.Exemple;

namespace API.Exemple.Core._08.Infrastructure.Database.Repositories;

public class ExempleRepository : BaseRepository<ExempleEntity>, IExempleRepository
{
    private readonly ExempleAppDbContext _context;
    public ExempleRepository(ExempleAppDbContext context) : base(context)
    {
        _context = context;
    }

}
