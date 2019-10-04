using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portfolio.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T Create(T entity);
        List<T> FindAll(Expression<Func<T, bool>> predicat);
    }
}