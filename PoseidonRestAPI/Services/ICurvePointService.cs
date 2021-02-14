using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface ICurvePointService
    {
        CurvePointDTO Add(EditCurvePointDTO editCurvePointDTO);
        void Delete(int Id);
        CurvePointDTO[] FindAll();
        CurvePointDTO FindById(int Id);
        void Update(int Id, EditCurvePointDTO editCurvePointDTO);
    }
}