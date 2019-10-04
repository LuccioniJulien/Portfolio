using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Portfolio.Interfaces;
using Portfolio.Models;

namespace Portfolio.Dao
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PortfolioEntities _context;
        
        public RepositoryBase(PortfolioEntities context) => _context = context;

        public T Create(T entity)
        {
            this._context.Set<T>().Add(entity);
            this._context.SaveChanges();
            return entity;
        }

        public List<T> FindAll(Expression<Func<T, bool>> predicat = null)
        {
            if (predicat != null)
            {
                return this._context.Set<T>()
                                    .Where(predicat)
                                    .ToList();
            }

            return this._context.Set<T>()
                                .ToList();
        }
    }
}