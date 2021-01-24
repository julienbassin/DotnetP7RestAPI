using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        ValueTask<T> GetByIdAsync(int Id);
        void Remove(object entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}