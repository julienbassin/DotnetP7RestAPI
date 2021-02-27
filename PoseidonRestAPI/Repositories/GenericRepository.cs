using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PoseidonRestAPI.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public LocalDbContext _context { get; }
        public GenericRepository(LocalDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = _context.Set<TEntity>().ToList();
            return result;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual TEntity FindById(int id)
        {
            var result = _context.Set<TEntity>().Find(id);
            return result ;
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _context.Set<TEntity>().Add(entity);            
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var entity = _context.Set<TEntity>().Find(Id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
