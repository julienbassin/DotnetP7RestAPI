using PoseidonRestAPI.Configuration;
using PoseidonRestAPI.Resources;

namespace PoseidonRestAPI.Services
{
    public interface IUserService
    {
        UserDTO CreateUser(EditUserDTO editUserDTO);
        void Delete(int Id);
        UserDTO[] FindAllUsers();
        UserDTO FindUserByName(string name);
        UserDTO FindUserById(int Id);
        void UpdateUser(int Id, EditUserDTO editUserDTO);
        void SaveJsonWebToken(JsonWebToken jsonWebToken, int userId);
    }
}