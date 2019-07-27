using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDoCoreApiTest
{
    public interface IRepository<T>
    {
        T Create(string text);
        T Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> Get(Predicate<T> match);
        T Upsert(T item);
    }
}