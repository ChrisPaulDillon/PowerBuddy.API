using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.Services.Authentication.Models
{
    public class AuthenticatedUserDTO 
    {
        public UserDTO User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
