namespace PowerBuddy.MediatR.Commands.Authentication.Models
{
    public class ChangePasswordInputDTO
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
