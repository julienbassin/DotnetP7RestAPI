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
    public class RuleRepository : GenericRepository<Rule>, IRuleRepository
    {
        public RuleRepository(LocalDbContext context) : base(context) { }

        public IEnumerable<Rule> GetAllRulesEntity()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<Rule> FindRuleEntity(Expression<Func<Rule, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public ValueTask<Rule> GetRuleEntityByIdAsync(int Id)
        {

            return _DbSet.FindAsync(Id);
        }

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddRuleEntityAsync(Rule entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            await _DbSet.AddAsync(entity);
        }

        public void UpdateRuleEntity(Rule entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity");
            }

            _DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveBidListEntityRange(IEnumerable<Rule> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public void RemoveBidListEntity(object entity)
        {
            Rule existing = _DbSet.Find(entity);
            _DbSet.Remove(existing);
        }
    }
}
