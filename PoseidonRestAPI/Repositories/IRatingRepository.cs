using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IRatingRepository
    {
        Task AddRatingEntityAsync(Rating entity);
        IEnumerable<Rating> FindRatingEntity(Expression<Func<Rating, bool>> predicate);
        IEnumerable<Rating> GetAllRatingsEntity();
        ValueTask<Rating> GetRatingEntityByIdAsync(int Id);
        void RemoveRatingEntity(object entity);
        void RemoveRatingEntityRange(IEnumerable<Rating> entities);
        void UpdateRatingEntity(Rating entity);
    }
}