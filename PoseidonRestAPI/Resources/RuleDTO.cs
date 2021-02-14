using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Resources
{
    public class RuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Json { get; set; }
        public string Template { get; set; }
        public string SqlStr { get; set; }
        public string SqlPart { get; set; }
    }

    public class EditRuleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Json { get; set; }
    }
}
