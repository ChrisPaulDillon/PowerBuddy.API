using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Accounts.Contracts;
using PowerLifting.Accounts.Contracts.Services;
using PowerLifting.Accounts.Service;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.Users.Validators;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Accounts.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;
        private UserManager<User> _userManager;
        private readonly UserValidation _validator;

        public UserService(IAccountWrapper repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _validator = new UserValidation();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _repo.User.GetAllUsers();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> LoginUser(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Email);
            if(user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            throw new InvalidCredentialsException();
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

        public async Task RegisterUser(RegisterUserDTO userDTO)
        {
            var user = await _repo.User.GetUserById(userDTO.Id);
            if (user != null) throw new EmailInUseException();
            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            await _userManager.CreateAsync(userEntity, userDTO.Password);
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