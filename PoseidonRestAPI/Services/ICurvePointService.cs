using PoseidonRestAPI.ModelValidator;
using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface ICurvePointService
    {
        CurvePointDTO Add(EditCurvePointDTO editCurvePointDTO);
        void Delete(int Id);
        CurvePointDTO[] FindAll();
        CurvePointDTO FindById(int Id);
        ValidationResult ValidateResource(EditCurvePointDTO editCurvePointDTO);
        void Update(int Id, EditCurvePointDTO editCurvePointDTO);
    }
}