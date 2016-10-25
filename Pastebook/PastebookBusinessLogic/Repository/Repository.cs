using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PastebookEntityFramework;
using System.Collections.Generic;

namespace PastebookDataAccess
{
    // source: http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle
    public class Repository<T> where T : class
    {
        public List<T> RetrieveAll()
        {
            List<T> result = new List<T>();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    result = context.Set<T>().ToList();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public List<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            List<T> result = new List<T>();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    result = context.Set<T>().Where(predicate).ToList();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public T RetrieveSpecific(Expression<Func<T, bool>> predicate)
        {
            T result = null;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    result = context.Set<T>().Single(predicate);
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public bool Check(Expression<Func<T, bool>> predicate)
        {
            bool result = false;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    result = context.Set<T>().Any(predicate);
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public int Add(T entity)
        {
            int result = 0;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.Set<T>().Add(entity);
                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public int Edit(T entity)
        {
            int result = 0;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.Entry(entity).State = EntityState.Modified;
                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }

        public int Delete(T entity)
        {
            int result = 0;

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.Set<T>().Remove(entity);
                    result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return result;
        }
    }
}