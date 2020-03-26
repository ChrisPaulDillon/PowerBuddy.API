using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Powerlifting.Services.Users.DTO;
using PowerLifting.Services.Service.Users.Exceptions;
using Powerlifting.Services.Users.Model;
using PowerLifting.Services.Users;
using PowerLifting.Services.Users.Exceptions;

namespace Powerlifting.Services.Users
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUserRepository _repo;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _repo.GetAllUsers();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserByEmail(string username)
        {
            var user = await _repo.GetUserByEmail(username);
            var userDTO = _mapper.Map<UserDTO>(user); 
            return userDTO;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            var user = await _repo.GetUserById(userDTO.UserId);
            if (user != null)
            {
                throw new EmailInUserException();
            }
            var userEntity = _mapper.Map<User>(userDTO);
            await _repo.CreateUser(userEntity);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var user = await _repo.GetUserById(userDTO.UserId);
            if(user == null)
            {
                throw new UserNotFoundException();
            }
            _mapper.Map(userDTO, user);
            _repo.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            _repo.DeleteUser(user);
        }

        Task<UserDTO> IUserService.CreateUser(UserDTO user)
        {
            throw new System.NotImplementedException();
        }
    }
}
