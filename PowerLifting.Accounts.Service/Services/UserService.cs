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
using PowerLifting.Service.UserSettings.Model;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using PowerLifting.Entity.Users.DTO;

namespace PowerLifting.Accounts.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IAccountWrapper _repo;
        private UserManager<User> _userManager;
        private readonly ApplicationSettings _appSettings;

        public UserService(IAccountWrapper repo, IMapper mapper, UserManager<User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _repo.User.GetAllUsers();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new UserNotFoundException();

            var userDTO = new UserDTO()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };
            return userDTO;
        }

        public async Task<PublicUserDTO> GetPublicUserProfile(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) throw new UserNotFoundException();

            var userDTO = new PublicUserDTO()
            {
                UserName = user.UserName,
                SportType = user.SportType,
            };
            return userDTO;
        }

        public async Task<string> LoginUser(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginModel.Email);
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var key = Encoding.UTF8.GetBytes(_appSettings.JWT_Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
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
            var user = await _repo.User.GetUserByEmail(userDTO.UserName);
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
            var user = await _repo.User.GetUserById(userDTO.UserId);
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