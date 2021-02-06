using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PowerBuddy.AuthenticationService.Configuration;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

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

        public async Task<string> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return null;
            }

            var expiryDate = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDate);

            if (expiryDateUtc > DateTime.UtcNow) //token has not expired yet
            {
                return null;
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            return "";
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
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                return !IsJwtWithValidSecurityAlgorithm(validatedToken) ? null : principal;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
