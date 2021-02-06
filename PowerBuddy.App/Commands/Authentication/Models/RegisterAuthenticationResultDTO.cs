using PowerBuddy.App.Services.Authentication.Models;

namespace PowerBuddy.App.Commands.Authentication.Models
{
    public class RegisterAuthenticationResultDto : AuthenticationResultDto
    {
        public string UserId { get; set; } //Used for send email confirmation logic
    }
}
