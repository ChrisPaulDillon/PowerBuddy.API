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
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthService(IJwtConfig jwtConfig, TokenValidationParameters tokenValidationParameters)
        {
            _jwtConfig = jwtConfig;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public string GenerateJwtToken(string userId, string userName, bool usingMetric, bool firstVisit, int memberStatusId)
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Key);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Issuer,
                new List<Claim>()
                {
                    new Claim("UserId", userId),
                    new Claim("UserName", userName),
                    new Claim("UsingMetric", usingMetric.ToString()),
                    new Claim("FirstVisit", firstVisit.ToString()),
                    new Claim("MemberStatusId", memberStatusId.ToString())
                },
                expires: DateTime.Now.Add(_jwtConfig.LifeTime),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenOptions);

            return token;
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
            return !IsJwtWithValidSecurityAlgorithm(validatedToken) ? null : principal;
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
