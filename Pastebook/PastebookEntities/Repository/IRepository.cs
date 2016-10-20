using System;
using System.Linq;
using System.Linq.Expressions;

namespace PastebookDataAccess.Repository
{
    // source: http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle
    public interface IRepository<T> where T : class
    {
        IQueryable<T> RetrieveAll();
        IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate);
        int Add(T entity);
        int Edit(T entity);
        int Delete(T entity);
    }
}
