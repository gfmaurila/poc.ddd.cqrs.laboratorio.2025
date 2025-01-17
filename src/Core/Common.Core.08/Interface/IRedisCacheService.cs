using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Interface;

public interface IRedisCacheService<T>
{
    Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null);
    Task<long> AddToListAsync(string listKey, T value);
    Task<T> GetOrCreateAsync(string key, Func<Task<T>> createItem, TimeSpan? expiry = null);
    Task<IEnumerable<T>> GetListAsync(string listKey);
    Task<long> RemoveFromListAsync(string listKey, T value);
    Task<T> GetAsync(string key);
    Task<bool> DeleteAsync(string key);
    Task ClearDatabaseAsync();
}