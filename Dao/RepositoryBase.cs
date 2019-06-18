using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Portfolio.Models;

namespace Portfolio.Dao
{
    // Classe qui implémentera le CRUD de façon générique
    public abstract class RepositoryBase<T> where T : class
    {
        protected PortfolioEntities _context;
        public RepositoryBase(PortfolioEntities context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicat = null)
        {
            if (predicat != null)
            {
                return this._context.Set<T>()
                                    .Where(predicat);
            }

            return this._context.Set<T>();
        }
    }
}