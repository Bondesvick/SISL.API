using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SISL.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(long id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);

        Task Add(T entity);

        Task Delete(T entity);

        Task Update(T entity);

        IQueryable<T> IncludeQuery(string[] includes);
    }
}