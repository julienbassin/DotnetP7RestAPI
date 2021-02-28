using PoseidonRestAPI.ModelValidator;
using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface ITradeService
    {
        TradeDTO Add(EditTradeDTO editTradeDTO);
        void Delete(int Id);
        TradeDTO[] FindAll();
        TradeDTO FindById(int Id);
        ValidationResult ValidateResource(EditTradeDTO editTradeDTO);
        void Update(int Id, EditTradeDTO editTradeDTO);
    }
}