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
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    return context.Set<T>().ToList();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return null;
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

        public List<PB_COMMENT> RetrieveComments(int postID)
        {
            List<PB_COMMENT> comments = new List<PB_COMMENT>();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    comments = context.PB_COMMENT.Where(x => x.POST_ID == postID).Include("PB_USER").ToList();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return comments;
        }

        public T RetrieveSpecific(Expression<Func<T, bool>> predicate)
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    return Retrieve(predicate).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return null;
        }

        public bool Check(Expression<Func<T, bool>> predicate)
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    return context.Set<T>().Any(predicate);
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return false;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    return context.Set<T>().Where(predicate).ToList().Count();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return 0;
        }

        public int Add(T entity)
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.Set<T>().Add(entity);
                    return context.SaveChanges();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return 0;
        }

        public int Edit(T entity)
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.Entry(entity).State = EntityState.Modified;
                    return context.SaveChanges();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return 0;
        }

        public int Delete(T entity)
        {
            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    context.Set<T>().Remove(entity);
                    return context.SaveChanges();
                }
                catch (Exception ex)
                {
                    List<Exception> exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return 0;
        }
    }
}