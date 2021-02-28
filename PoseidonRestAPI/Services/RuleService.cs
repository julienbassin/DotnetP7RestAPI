using AutoMapper;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.ModelValidator;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Services
{
    public class RuleService : IRuleService
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

        public ValidationResult ValidateResource(EditRuleDTO editRuleDTO)
        {
            var result = new ValidationResult();
            if (editRuleDTO != null)
            {
                var validator = new RuleValidator();
                var vr = validator.Validate(editRuleDTO);
                if (vr.IsValid)
                {
                    result.IsValid = true;
                    return result;
                }

                if (vr.Errors.Any())
                {
                    foreach (var error in vr.Errors)
                    {
                        result.ErrorMessages.Add(error.PropertyName, error.ErrorMessage);
                    }
                }
            }

            return result;
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
                _ruleRepository.Update(Id, _mapper.Map(editRuleDTO, updateRule));
            }
        }

        public void Delete(int Id)
        {
            _ruleRepository.Delete(Id);
        }
    }
}
