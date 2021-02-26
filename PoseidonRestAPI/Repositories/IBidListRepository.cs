using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IBidListRepository : IGenericRepository<BidList> 
    {
        void Update(int Id, BidList entity);
    }
}
