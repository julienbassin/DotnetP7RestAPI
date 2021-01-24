using System.Linq;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;

namespace PoseidonRestAPI.Repositories
{
    public class UserRepository
    {
        public LocalDbContext DbContext { get; }

        public UserRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public User FindByUserName(string userName)
        {
            return DbContext.Users.Where(user => user.UserName == userName)
                                  .FirstOrDefault();
        }

        public User[] FindAll()
        {
            return DbContext.Users.ToArray();
        }

        public void Add(User user)
        {
        }

        public User FindById(int id)
        {
            return null;
        }
    }
}