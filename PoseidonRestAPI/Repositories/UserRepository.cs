using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;

namespace PoseidonRestAPI.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LocalDbContext context) : base(context) { }

        public IEnumerable<User> GetAllUsersEntity()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<User> FindUserEntity(Expression<Func<User, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<User> GetUserEntityByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddUserEntityAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void UpdateUserEntity(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveUserEntityRange(IEnumerable<User> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void RemoveUserEntity(object entity)
        {
            User existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }
    }
}