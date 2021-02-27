using PoseidonRestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IRuleRepository : IGenericRepository<Rule>
    {
        void Update(int Id, Rule entity);
    }
}