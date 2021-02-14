using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                              IMapper mapper)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));

            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(_userRepository));
        }

        // find
        public UserDTO[] FindAll()
        {
            return _userRepository.GetAll()
                               .Where(x => x.Id > 0)
                               .Select(x => _mapper.Map<UserDTO>(x)).ToArray();
        }

        public UserDTO FindById(int Id)
        {
            var _user = _userRepository.FindById(Id);
            return _mapper.Map<UserDTO>(_user);
        }

        // add 
        public UserDTO Add(EditUserDTO editUserDTO)
        {
            if (editUserDTO == null)
            {
                throw new ArgumentException();
            }

            var currentUser = _mapper.Map<User>(editUserDTO);
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

        // edit
        public void Update(int Id, EditUserDTO editUserDTO)
        {
            var updateUser = _userRepository.FindById(Id);
            if (updateUser != null && editUserDTO != null)
            {
                //_bidListRepository.Update(Id, updateBidList);
            }
        }

        public void Delete(int Id)
        {
            _userRepository.Delete(Id);
        }
    }
}
