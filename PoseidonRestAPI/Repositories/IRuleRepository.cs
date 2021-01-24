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
        void RemoveRuleEntity(object entity);
        void RemoveRuleEntityRange(IEnumerable<Rule> entities);
        void UpdateRuleEntity(Rule entity);
    }
}