using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly LocalDbContext _context;
        private DbSet<T> _entities;
        string errorMessage = string.Empty;

        public RepositoryBase(LocalDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int Id)
        {
            return _entities.SingleOrDefault(s => s.Id == Id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
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

            T _entity = _entities.SingleOrDefault(s => s.Id == Id);
            if (_entity == null)
            {
                throw new ArgumentException("Entity");
            }
            _entities.Remove(_entity);
            _context.SaveChanges();
        }
    }
}
