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
    public class CurvePointRepository : GenericRepository<CurvePoint>, ICurvePointRepository
    {
        public CurvePointRepository(LocalDbContext context) : base(context) { }

        public IEnumerable<CurvePoint> GetAllCurvePointEntity()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<CurvePoint> FindBidList(Expression<Func<CurvePoint, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<CurvePoint> GetBidListByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddCurvePointEntityAsync(CurvePoint entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void UpdateCurvePointEntity(CurvePoint entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveCurvePointEntityRange(IEnumerable<CurvePoint> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void RemoveCurvePointEntity(object entity)
        {
            CurvePoint existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }

    }
}
