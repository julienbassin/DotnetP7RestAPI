using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface ITradeService
    {
        TradeDTO Add(EditTradeDTO editTradeDTO);
        void Delete(int Id);
        TradeDTO[] FindAll();
        TradeDTO FindById(int Id);
        void Update(int Id, EditTradeDTO editTradeDTO);
    }
}