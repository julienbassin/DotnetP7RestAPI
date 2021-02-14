using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IRuleService
    {
        RuleDTO Add(EditRuleDTO editRuleDTO);
        void Delete(int Id);
        RuleDTO[] FindAll();
        RuleDTO FindById(int Id);
        void Update(int Id, EditRuleDTO editRuleDTO);
    }
}