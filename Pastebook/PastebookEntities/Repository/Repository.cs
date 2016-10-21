using PastebookDataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PastebookDataAccess
{
    // source: http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle
    public class Repository<C, T> : IRepository<T> where T : class where C : DbContext, new()
    {
        private C _context = new C();

        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public IQueryable<T> Retrieve()
        {
            IQueryable<T> result = null;

            result = _context.Set<T>();

            return result;
        }

        public IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = null;

            result = _context.Set<T>().Where(predicate);

            return result;
        }

        public int Add(T entity)
        {
            int result = 0;

            _context.Set<T>().Add(entity);
            result = Save();

            return result;
        }

        public int Edit(T entity)
        {
            int result = 0;

            _context.Entry(entity).State = EntityState.Modified;
            result = Save();

            return result;
        }

        public int Delete(T entity)
        {
            int result = 0;

            _context.Set<T>().Remove(entity);
            result = Save();

            return result;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}