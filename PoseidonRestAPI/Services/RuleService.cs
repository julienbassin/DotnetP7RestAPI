using AutoMapper;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Services
{
    public class RuleService
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly IMapper _mapper;

        public RuleService(IRuleRepository ruleRepository,
                              IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));

            _ruleRepository = ruleRepository ??
                throw new ArgumentNullException(nameof(_ruleRepository));
        }

        // find
        public RuleDTO[] FindAll()
        {
            return _ruleRepository.GetAll()
                               .Where(x => x.Id > 0)
                               .Select(x => _mapper.Map<RuleDTO>(x)).ToArray();
        }

        public RuleDTO FindById(int Id)
        {
            var _rule = _ruleRepository.FindById(Id);
            return _mapper.Map<RuleDTO>(_rule);
        }

        // add 
        public RuleDTO Add(EditRuleDTO editRuleDTO)
        {
            if (editRuleDTO == null)
            {
                throw new ArgumentException();
            }

            var currentRule = _mapper.Map<Rule>(editRuleDTO);
            try
            {
                _ruleRepository.Insert(currentRule);
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<RuleDTO>(currentRule);
        }

        // edit
        public void Update(int Id, EditRuleDTO editRuleDTO)
        {
            var updateRule = _ruleRepository.FindById(Id);
            if (updateRule != null && editRuleDTO != null)
            {
                //_bidListRepository.Update(Id, updateBidList);
            }
        }

        public void Delete(int Id)
        {
            _ruleRepository.Delete(Id);
        }
    }
}
