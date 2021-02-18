using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void Update(int Id, User user);
    }
}