using Common.Core._08.Domain.Interface;
using Common.Core._08.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Exemple.Core._08.Infrastructure.Database.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ExempleAppDbContext _context;

    public BaseRepository(ExempleAppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task Remove(T obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<T> Get(Guid id)
    {
        var obj = await _context.Set<T>()
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();
    }
}
