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
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        public TradeRepository(LocalDbContext context) : base(context) { }

        public void Update(int Id, Trade entity)
        {
            var updatedTrade = _context.Trades.Find(Id);
            if (updatedTrade != null && entity != null)
            {
                updatedTrade.Account = entity.Account;

                _context.Trades.Update(entity);
                _context.SaveChanges();
            }
        }

    }
}
