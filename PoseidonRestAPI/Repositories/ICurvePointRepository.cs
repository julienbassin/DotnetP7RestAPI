using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface ICurvePointRepository
    {
        Task AddCurvePointEntityAsync(CurvePoint entity);
        IEnumerable<CurvePoint> FindBidList(Expression<Func<CurvePoint, bool>> predicate);
        IEnumerable<CurvePoint> GetAllCurvePointEntity();
        ValueTask<CurvePoint> GetBidListByIdAsync(int Id);
        void RemoveCurvePointEntity(object entity);
        void RemoveCurvePointEntityRange(IEnumerable<CurvePoint> entities);
        void UpdateCurvePointEntity(CurvePoint entity);
    }
}