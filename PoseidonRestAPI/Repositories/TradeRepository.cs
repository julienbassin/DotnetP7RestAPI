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

        public IEnumerable<Trade> GetAllTradesEntity()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<Trade> FindTradeEntity(Expression<Func<Trade, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<Trade> GetTradeEntityByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddTradeEntityAsync(Trade entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void UpdateTradeEntity(Trade entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveTradeEntityRange(IEnumerable<Trade> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void RemoveTradeEntity(object entity)
        {
            Trade existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }
    }
}
