using PoseidonRestAPI.ModelValidator;
using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IRuleService
    {
        RuleDTO Add(EditRuleDTO editRuleDTO);
        void Delete(int Id);
        RuleDTO[] FindAll();
        RuleDTO FindById(int Id);
        ValidationResult ValidateResource(EditRuleDTO editRuleDTO);
        void Update(int Id, EditRuleDTO editRuleDTO);
    }
}