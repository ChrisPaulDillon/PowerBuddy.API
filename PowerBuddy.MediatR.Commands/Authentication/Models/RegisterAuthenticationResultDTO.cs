using PowerBuddy.Services.Authentication.Models;

namespace PowerBuddy.MediatR.Commands.Authentication.Models
{
    public class RegisterAuthenticationResultDTO : AuthenticationResultDTO
    {
        public string UserId { get; set; } //Used for send email confirmation logic
    }
}
