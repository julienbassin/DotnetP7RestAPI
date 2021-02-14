using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;

namespace PoseidonRestAPI.Repositories
{
    public class CurvePointRepository : GenericRepository<CurvePoint>, ICurvePointRepository
    {
        public CurvePointRepository(LocalDbContext context) : base(context) { }

        public void Update(int Id, CurvePoint entity)
        {
            var cp = _context.CurvePoints.Find(Id);
            if (cp != null && entity != null)
            {
                _context.CurvePoints.Update(entity);
                _context.SaveChanges();
            }
        }

    }
}
