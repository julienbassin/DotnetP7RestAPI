using PoseidonRestAPI.ModelValidator;
using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IBidListService
    {
        BidListDTO Add(EditBidListDTO editBidListDTO);
        BidListDTO[] FindAll();
        BidListDTO FindById(int Id);

        ValidationResult ValidateResource(EditBidListDTO editBidListDTO);
        void Update(int Id, EditBidListDTO editBidListDTO);
        void Delete(int Id);
    }
}