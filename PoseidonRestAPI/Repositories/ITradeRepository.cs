using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface ITradeRepository
    {
        Task AddTradeEntityAsync(Trade entity);
        IEnumerable<Trade> FindTradeEntity(Expression<Func<Trade, bool>> predicate);
        IEnumerable<Trade> GetAllTradesEntity();
        ValueTask<Trade> GetTradeEntityByIdAsync(int Id);
        void RemoveTradeEntity(object entity);
        void RemoveTradeEntityRange(IEnumerable<Trade> entities);
        void UpdateTradeEntity(Trade entity);
    }
}