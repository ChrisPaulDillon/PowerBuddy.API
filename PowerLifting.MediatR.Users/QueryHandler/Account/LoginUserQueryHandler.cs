using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Query.Account;

namespace PowerLifting.MediatR.Users.QueryHandler.Account
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public LoginUserQueryHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.LoginModel.Email)) throw new UserValidationException("Email cannot be empty");
            if (string.IsNullOrEmpty(request.LoginModel.Password)) throw new UserValidationException("Password cannot be empty");
            if (string.IsNullOrEmpty(request.LoginModel.UserName)) throw new UserValidationException("UserName cannot be empty");

            var user = await _context.User.AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.NormalizedEmail == request.LoginModel.Email.ToUpper() ||
                    x.NormalizedUserName == request.LoginModel.UserName, cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            if (await _userManager.CheckPasswordAsync(user, request.LoginModel.Password))
            {
                var key = Encoding.UTF8.GetBytes("gfgfd"); //TODO Encoding.UTF8.GetBytes(_jwtSettings.JWT_Secret); 
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
    }
}