using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PoseidonRestAPI.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public LocalDbContext _context = null;
        public DbSet<T> _DbSet = null;
        public GenericRepository(LocalDbContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<T> GetByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void Remove(object entity)
        {
            T existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }
    }
}
