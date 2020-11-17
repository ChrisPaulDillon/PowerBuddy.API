using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.MediatR.Users.Models
{
    public class UserLoggedInDTO 
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
