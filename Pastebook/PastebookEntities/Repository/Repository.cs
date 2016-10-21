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

            try
            {
                result = _context.Set<T>();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = null;

            try
            {
                result = _context.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public virtual int Add(T entity)
        {
            int result = 0;

            try
            {
                _context.Set<T>().Add(entity);
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public virtual int Edit(T entity)
        {
            int result = 0;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }

        public virtual int Delete(T entity)
        {
            int result = 0;

            try
            {
                _context.Set<T>().Remove(entity);
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                foreach (var exception in exceptionList)
                {
                    throw new Exception(exception.Message, ex);
                }
            }

            return result;
        }
    }
}