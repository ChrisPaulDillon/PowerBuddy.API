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
            if (string.IsNullOrEmpty(userId)) throw new UserValidationException("UserId cannot be empty");

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

        public async Task<PublicUserDTO> GetPublicUserProfileById(string userId)
        {
            if (string.IsNullOrEmpty(userId)) throw new UserValidationException("UserId cannot be empty");

            var user = await _context.User.Where(x => x.Id == userId)
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException();

            return user;
        }

        public async Task<PublicUserDTO> GetPublicUserProfileByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new UserValidationException("UserName cannot be empty");

            var user = await _context.User.Where(x => x.NormalizedUserName == userName.ToUpper())
               .AsNoTracking()
               .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException();

            return user;
        }

        public async Task<string> LoginUser(LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Email)) throw new UserValidationException("Email cannot be empty");
            if (string.IsNullOrEmpty(loginModel.Password)) throw new UserValidationException("Password cannot be empty");
            if (string.IsNullOrEmpty(loginModel.UserName)) throw new UserValidationException("UserName cannot be empty");

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
            if (string.IsNullOrEmpty(userDTO.Email)) throw new UserValidationException("Email cannot be empty");
            if (string.IsNullOrEmpty(userDTO.Password)) throw new UserValidationException("Password cannot be empty");
            if (string.IsNullOrEmpty(userDTO.UserName)) throw new UserValidationException("UserName cannot be empty");

            var doesUserExist = await _context.User.AsNoTracking().AnyAsync(x => x.Email == userDTO.Email || x.NormalizedUserName == userDTO.UserName.ToUpper());
            if (doesUserExist) throw new EmailOrUserNameInUseException();

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

        public async Task<bool> BanUser(string userId, string adminUserId)
        {
            var userToBan = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);

            if (userToBan == null) throw new UserNotFoundException();

            var adminUser = await _context.User.Where(x => x.Id == adminUserId && x.Rights >= 1).Select(x => x.UserName).FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(adminUser)) throw new UserNotFoundException();

            userToBan.IsBanned = true;
            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }
    }
}