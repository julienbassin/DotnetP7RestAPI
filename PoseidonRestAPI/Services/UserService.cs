using AutoMapper;
using PoseidonRestAPI.Configuration;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTTokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IJWTTokenRepository tokenRepository,
                           IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));

            _tokenRepository = tokenRepository ??
                throw new ArgumentNullException(nameof(_tokenRepository));

            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(_userRepository));
        }

        // find
        public UserDTO[] FindAllUsers()
        {
            return _userRepository.GetAll()
                               .Where(x => x.Id > 0)
                               .Select(x => _mapper.Map<UserDTO>(x)).ToArray();
        }

        public UserDTO FindUserById(int Id)
        {
            var _user = _userRepository.FindById(Id);
            return _mapper.Map<UserDTO>(_user);
        }

        public UserDTO FindUserByName(string name)
        {
            var _user = _userRepository.FindUserByName(name);
            return _mapper.Map<UserDTO>(_user);
        }

        // add user  + generate token ? 
        public UserDTO CreateUser(EditUserDTO editUserDTO)
        {
            if (editUserDTO == null)
            {
                throw new ArgumentException();
            }

            var currentUser = _mapper.Map<User>(editUserDTO);
            var hashedPassword = JsonWebToken.GenerateHash(editUserDTO.Password, "128");
            currentUser.Password = hashedPassword;

            try
            {
                _userRepository.Insert(currentUser);
            }
            catch (Exception)
            {
                throw;
            }
            return _mapper.Map<UserDTO>(currentUser);
        }


        public void SaveJsonWebToken(JsonWebToken jsonWebToken, int userId)
        {
            if (jsonWebToken != null && userId > 0)
            {
                var currentToken = _tokenRepository.GetJWTTokenById(userId);
                if (currentToken != null)
                {
                    _tokenRepository.RemoveAccessToken(currentToken.UserId);
                }
                _tokenRepository.SaveAccessToken(jsonWebToken, userId);
            }
        }

        // edit user + token  ?
        public void UpdateUser(int Id, EditUserDTO editUserDTO)
        {
            var updateUser = _userRepository.FindById(Id);
            if (updateUser != null && editUserDTO != null)
            {
                var hashedPassword = JsonWebToken.GenerateHash(editUserDTO.Password, "128");
                editUserDTO.Password = hashedPassword;
                _userRepository.Update(Id, _mapper.Map(editUserDTO, updateUser));
            }
        }

        public bool CheckUser(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return false;
            }
            var currentUser = _userRepository.FindUserByName(username);
            if (currentUser == null)
            {
                return false;
            }

            return JsonWebToken.AreEqual(password, currentUser.Password , "128");
        }

        // delete user
        public void Delete(int Id)
        {
            _userRepository.Delete(Id);
        }

        public UserDTO GetUserJwtToken(string jsonWebToken)
        {
            var currentToken = _tokenRepository.GetJWTToken(jsonWebToken);
            var currentuser = _userRepository.FindById(currentToken.UserId);
            return _mapper.Map<UserDTO>(currentuser);
        }
    }
}
