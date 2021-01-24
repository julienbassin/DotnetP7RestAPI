using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IUserRepository
    {
        Task AddUserEntityAsync(User entity);
        IEnumerable<User> FindUserEntity(Expression<Func<User, bool>> predicate);
        IEnumerable<User> GetAllUsersEntity();
        ValueTask<User> GetUserEntityByIdAsync(int Id);
        void RemoveUserEntity(object entity);
        void RemoveUserEntityRange(IEnumerable<User> entities);
        void UpdateUserEntity(User entity);
    }
}