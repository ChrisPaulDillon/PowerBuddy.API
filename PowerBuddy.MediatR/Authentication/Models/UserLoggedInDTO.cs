using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.MediatR.Authentication.Models
{
    public class UserLoggedInDTO 
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
