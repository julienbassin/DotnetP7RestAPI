using Microsoft.EntityFrameworkCore;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public class BidListRepository : GenericRepository<BidList>, IBidListRepository
    {
        public BidListRepository(LocalDbContext context):base(context)
        {
            
        }

        

    }
}
