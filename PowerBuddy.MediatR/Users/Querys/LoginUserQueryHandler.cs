using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtConfig _jwtConfig;

        public LoginUserQueryHandler(PowerLiftingContext context, IMapper mapper, SignInManager<User> signInManager, IJwtConfig jwtConfig)
        {
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig;
        }

        public async Task<UserLoggedInDTO> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User
	            .FirstOrDefaultAsync(x => x.NormalizedEmail == request.LoginModel.Email.ToUpper() || x.NormalizedUserName == request.LoginModel.UserName.ToUpper());

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!user.EmailConfirmed)
            {
                throw new EmailNotConfirmedException(user.Id);
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.LoginModel.Password, true, true);

            if (result.IsLockedOut)
            {
	            throw new AccountLockoutException();
            }

            if (result.Succeeded)
            {
	            var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);
                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtConfig.Issuer,
                    audience: _jwtConfig.Issuer, 
                    new List<Claim>()
                    {
                        new Claim("UserId", user.Id.ToString())
                    }, 
                    expires: DateTime.Now.AddDays(5), 
                    signingCredentials: signingCredentials
                    );
            
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.WriteToken(tokenOptions);

                var userProfile = _mapper.Map<UserDTO>(user);

                if (userProfile == null)
                {
	                throw new UserNotFoundException();
                }

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