using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IUserService
    {
        UserDTO CreateUser(EditUserDTO editUserDTO);
        void Delete(int Id);
        UserDTO[] FindAllUsers();
        UserDTO FindUserById(int Id);
        void UpdateUser(int Id, EditUserDTO editUserDTO);
    }
}