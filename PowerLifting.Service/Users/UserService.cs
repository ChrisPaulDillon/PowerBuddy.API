using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

        public UserService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _repo.User.GetAllUsers();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _repo.User.GetUserById(id);
            if (user == null) throw new UserNotFoundException();
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserByEmail(string username)
        {
            var user = await _repo.User.GetUserByEmail(username);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task RegisterUser(RegisterUserDTO userDTO, string password)
        {
            var user = await _repo.User.GetUserById(userDTO.Id);
            if (user != null) throw new EmailInUseException();
            var userEntity = _mapper.Map<User>(userDTO);
            //await _userManager.CreateAsync(userEntity, password);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var user = await _repo.User.GetUserById(userDTO.Id);
            if (user == null) throw new UserNotFoundException();
            _mapper.Map(userDTO, user);
            _repo.User.UpdateUser(user);
        }

        public async Task DeleteUser(string id)
        {
            var user = await _repo.User.GetUserById(id);
            if (user == null) throw new UserNotFoundException();
            _repo.User.DeleteUser(user);
        }
    }
}