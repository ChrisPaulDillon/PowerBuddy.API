using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.AuthenticationService.Configuration;

namespace PowerBuddy.AuthenticationService
{
    public class AuthService : IAuthService
    {
        private readonly IJwtConfig _jwtConfig;

        public AuthService(IJwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string GenerateJwtToken(string userId)
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Issuer,
                new List<Claim>()
                {
                    new Claim("UserId", userId)
                },
                expires: DateTime.Now.AddDays(5),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenOptions);

            return token;
        }
    }
}
