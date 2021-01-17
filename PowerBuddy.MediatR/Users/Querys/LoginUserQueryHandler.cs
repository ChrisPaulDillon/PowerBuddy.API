using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Util;
using PowerBuddy.MediatR.Users.Models;

namespace PowerBuddy.MediatR.Users.Querys
{
    public class LoginUserQuery : IRequest<UserLoggedInDTO>
    {
        public LoginModelDTO LoginModel { get; }

        public LoginUserQuery(LoginModelDTO loginModel)
        {
            LoginModel = loginModel;
            new LoginUserQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.LoginModel.UserName).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.LoginModel.Email).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.LoginModel.Password).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoggedInDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JWTSettings _jwtSettings;
        public LoginUserQueryHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager, JWTSettings jwtSettings)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<UserLoggedInDTO> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.NormalizedEmail == request.LoginModel.Email.ToUpper() ||
                    x.NormalizedUserName == request.LoginModel.UserName, cancellationToken: cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!user.EmailConfirmed)
            {
                throw new EmailNotConfirmedException(user.Id);
            }

            if (await _userManager.CheckPasswordAsync(user, request.LoginModel.Password))
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

                var userProfile = await _context.User
                    .Where(x => x.Id == user.Id)
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                if (userProfile == null) throw new UserNotFoundException();

                userProfile.UserSetting = await _context.UserSetting
                    .AsNoTracking()
                    .ProjectTo<UserSettingDTO>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken: cancellationToken);

                var userWithToken = new UserLoggedInDTO()
                {
                    Token = token,
                    User = userProfile
                };
                return userWithToken;
            }
            throw new InvalidCredentialsException();
        }
    }
}