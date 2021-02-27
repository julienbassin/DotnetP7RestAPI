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

        public void Update(int Id, User user)
        {
            if (user != null && Id > 0)
            {
                var currentuser = _context.Users.Find(Id);
                currentuser.FullName = user.FullName;
                currentuser.UserName = user.UserName;
                currentuser.Password = user.Password;
                currentuser.Role = user.Role;
                _context.Users.Update(currentuser);
                _context.SaveChanges();
            }

        }

        public User FindUserByName(string username)
        {
            if ( String.IsNullOrEmpty(username))
            {
                return null;
            }
            return _context.Users.Where(x => x.UserName == username).FirstOrDefault();
        }
    }
}