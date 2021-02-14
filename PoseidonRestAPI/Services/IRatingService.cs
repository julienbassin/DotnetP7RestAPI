using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IRatingService
    {
        RatingDTO Add(EditRatingDTO editRatingDTO);
        void Delete(int Id);
        RatingDTO[] FindAll();
        RatingDTO FindById(int Id);
        void Update(int Id, EditRatingDTO editRatingDTO);
    }
}