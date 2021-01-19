using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PoseidonRestAPI.Data;
using System.Linq.Expressions;

namespace PoseidonRestAPI.Repositories
{
    public class RepositoryBase<TEntity>  where TEntity : class
    {
        public readonly LocalDbContext _context;
        string errorMessage = string.Empty;

        public RepositoryBase(LocalDbContext context)
        {
            _context = context;
        }

        public virtual TEntity[] GetAll()
        {
            return _context.Set<TEntity>().ToArray();
        }

        public TEntity GetById(Expression<<>>)
        {
            //use predicate
            return _entities.SingleOrDefault(s => s.Id == Id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _context.Add(entity);
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

        public void DeleteAll()
        {
            // implement remove all entities
        }

        public void DeleteById(int Id)
        {
            if (Id < 0)
            {
                throw new ArgumentException("Entity");
            }

            TEntity _entity = _context.SingleOrDefault(s => s.Id == Id);
            if (_entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _context.Remove(_entity);
            _context.SaveChanges();
        }
    }
}
