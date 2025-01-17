using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Domain.Interface;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Remove(T obj);
    Task<T> Get(Guid id);
    Task<List<T>> Get();
}
