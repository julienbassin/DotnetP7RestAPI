using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IBidListService
    {
        BidListDTO Add(EditBidListDTO editBidListDTO);
        BidListDTO[] FindAll();
        BidListDTO FindById(int Id);

        void Update(int Id, EditBidListDTO editBidListDTO);
        void Delete(int Id);
    }
}