using Microsoft.EntityFrameworkCore;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public class BidListRepository : GenericRepository<BidList>, IBidListRepository
    {
        public BidListRepository(LocalDbContext context) : base(context) { }

        //public override void Update(int Id, BidList entity)
        //{
        //    var _UpdatedBidRepo = _context.BidList.Find(Id);
        //    if (_UpdatedBidRepo != null && entity != null)
        //    {
        //        _context.BidList.Update(_UpdatedBidRepo);
        //    }
        //}
    }
}
