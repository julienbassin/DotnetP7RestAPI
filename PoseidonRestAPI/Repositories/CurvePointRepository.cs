using PoseidonRestAPI.Data;
using PoseidonRestAPI.Domain;

namespace PoseidonRestAPI.Repositories
{
    public class CurvePointRepository : GenericRepository<CurvePoint>, ICurvePointRepository
    {
        public CurvePointRepository(LocalDbContext context) : base(context) { }
        
    }
}
