using PowerBuddy.App.Services.Authentication.Models;

namespace PowerBuddy.App.Commands.Authentication.Models
{
    public class RegisterAuthenticationResultDTO : AuthenticationResultDTO
    {
        public string UserId { get; set; } //Used for send email confirmation logic
    }
}
