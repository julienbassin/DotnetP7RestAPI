using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IRuleRepository
    {
        Task AddRuleEntityAsync(Rule entity);
        IEnumerable<Rule> FindRuleEntity(Expression<Func<Rule, bool>> predicate);
        IEnumerable<Rule> GetAllRulesEntity();
        ValueTask<Rule> GetRuleEntityByIdAsync(int Id);
        void RemoveBidListEntity(object entity);
        void RemoveBidListEntityRange(IEnumerable<Rule> entities);
        void UpdateRuleEntity(Rule entity);
    }
}