using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Util;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Service
{
    public class UserService : IUserService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JWTSettings _jwtSettings;

        public UserService(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager, JWTSettings jwtSettings)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<IEnumerable<AdminUserDTO>> GetAllAdminUsers()
        {
            var users = await _context.User.ProjectTo<AdminUserDTO>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();
            return users;
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

        public async Task<PublicUserDTO> GetPublicUserProfileById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new UserNotFoundException();

            var userDTO = new PublicUserDTO()
            {
                UserName = user.UserName,
                SportType = user.SportType,
            };
            return userDTO;
        }

        public async Task<PublicUserDTO> GetPublicUserProfileByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) throw new UserNotFoundException();

            var userDTO = new PublicUserDTO()
            {
                UserId = user.Id,
                UserName = user.UserName,
                SportType = user.SportType,
                IsPublic = user.IsPublic
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
                var key = Encoding.UTF8.GetBytes(_jwtSettings.JWT_Secret);
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

        public async Task RegisterUser(RegisterUserDTO userDTO)
        {
            var doesUserExist = await _context.User.AsNoTracking().AnyAsync(x => x.Email == userDTO.Email || x.UserName == userDTO.UserName);
            if (doesUserExist) throw new EmailInUseException();

            var userEntity = _mapper.Map<User>(userDTO);

            userEntity.UserSetting = new UserSetting()
            {
                UserId = userEntity.Id
            };

            await _userManager.CreateAsync(userEntity, userDTO.Password);
        }

        public async Task<IEnumerable<PublicUserDTO>> GetAllActivePublicProfiles()
        {
            return await _context.User.Where(x => x.IsPublic)
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}