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
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(LocalDbContext context) : base(context) { }

        public IEnumerable<Rating> GetAllRatingsEntity()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<Rating> FindRatingEntity(Expression<Func<Rating, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<Rating> GetRatingEntityByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddRatingEntityAsync(Rating entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void UpdateRatingEntity(Rating entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveRatingEntityRange(IEnumerable<Rating> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void RemoveRatingEntity(object entity)
        {
            Rating existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }
    }
}
