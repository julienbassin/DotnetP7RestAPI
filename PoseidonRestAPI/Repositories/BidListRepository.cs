using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;

namespace PoseidonRestAPI.Repositories
{
    public class BidListRepository : GenericRepository<BidList>, IBidListRepository
    {
        public BidListRepository(LocalDbContext context) : base(context) { }

        public void Update(int Id, BidList entity)
        {
            var _UpdatedBidRepo = _context.BidList.Find(Id);
            if (_UpdatedBidRepo != null && entity != null)
            {
                _UpdatedBidRepo.Account = entity.Account;
                _context.BidList.Update(_UpdatedBidRepo);
            }
        }
    }
}
