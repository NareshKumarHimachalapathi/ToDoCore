using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoCoreApiTest
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(string text);
        T DeleteAsync(string id);
        Task<T> GetAsync(string id);
        IEnumerable<T> GetAsync(Predicate<T> match);
        Task<T> UpsertAsync(T item);
    }
}