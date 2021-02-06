using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IBidListService
    {
        BidListDTO Add(EditBidListDTO editBidListDTO);
        BidListDTO[] FindAll();
        BidListDTO FindById(int Id);
        void Delete(int Id);
    }
}