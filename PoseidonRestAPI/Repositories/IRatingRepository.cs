using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        void Update(int Id, Rating entity);
    }
}
