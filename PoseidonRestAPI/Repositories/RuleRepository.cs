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

        public void Update(int Id, Rule entity)
        {
            var updatedRule = _context.Rules.Find(Id);
            if (updatedRule != null && entity != null)
            {
                updatedRule.Name = entity.Name;
                updatedRule.Description = entity.Description;
                updatedRule.Json = entity.Json;
                _context.Rules.Update(entity);
                _context.SaveChanges();
            }
        }

    }
}
