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

        public IEnumerable<BidList> GetAllBidlist()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<BidList> FindBidList(Expression<Func<BidList, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<BidList> GetBidListByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddBidlistAsync(BidList entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void UpdateBidlist(BidList entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveBidListRange(IEnumerable<BidList> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void RemoveBidlist(object entity)
        {
            BidList existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }

    }
}
