using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.Services.Authentication.Models
{
    public class AuthenticationResultDTO 
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
