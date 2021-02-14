using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IUserService
    {
        UserDTO Add(EditUserDTO editUserDTO);
        void Delete(int Id);
        UserDTO[] FindAll();
        UserDTO FindById(int Id);
        void Update(int Id, EditUserDTO editUserDTO);
    }
}