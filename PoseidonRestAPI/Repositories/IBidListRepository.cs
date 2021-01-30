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
        //IEnumerable<BidList> GetAllBidlistEntity();
        //IEnumerable<BidList> FindBidListEntity(Expression<Func<BidList, bool>> predicate);
        //ValueTask<BidList> GetBidListEntityByIdAsync(int Id);
        //Task AddBidListEntityAsync(BidList entity);
        //void UpdateBidListEntity(BidList entity);

        //void RemoveBidListEntityRange(IEnumerable<BidList> entities);
        //void RemoveBidListEntity(object entity);
    }
}
