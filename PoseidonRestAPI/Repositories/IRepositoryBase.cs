using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void DeleteAll();
        void DeleteById(int Id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TEntity> GetByIdAsync(int Id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
    }
}