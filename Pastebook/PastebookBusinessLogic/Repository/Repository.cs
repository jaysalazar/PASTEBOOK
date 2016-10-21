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
        public List<T> Retrieve()
        {
            List<T> result = new List<T>();

            using (var context = new PASTEBOOK_DBEntities())
            {
                result = context.Set<T>().ToList();
            }

            return result;
        }

        public List<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            List<T> result = new List<T>();

            using (var context = new PASTEBOOK_DBEntities())
            {
                result = context.Set<T>().Where(predicate).ToList();
            }

            return result;
        }

        public int Add(T entity)
        {
            int result = 0;

            using (var context = new PASTEBOOK_DBEntities())
            {
                context.Set<T>().Add(entity);
                result = Save();
            }

            return result;
        }

        public int Edit(T entity)
        {
            int result = 0;

            using (var context = new PASTEBOOK_DBEntities())
            {
                context.Entry(entity).State = EntityState.Modified;
                result = Save();
            }

            return result;
        }

        public int Delete(T entity)
        {
            int result = 0;

            using (var context = new PASTEBOOK_DBEntities())
            {
                context.Set<T>().Remove(entity);
                result = Save();
            }

            return result;
        }

        public int Save()
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                return context.SaveChanges();
            }
        }
    }
}