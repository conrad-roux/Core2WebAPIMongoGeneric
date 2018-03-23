using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core2WebAPIMongoGeneric.Interface
{
    public interface IService<T> : IDisposable where T : class
    {
        IEnumerable<string> Get(Expression<Func<T, bool>> predicate);
        string GetById(Expression<Func<T, bool>> predicate);
        string Create(T entity);
        string Update(string id, T entity);
        string Delete(string id);
    }
}
