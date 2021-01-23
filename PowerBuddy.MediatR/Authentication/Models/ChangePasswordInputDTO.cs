namespace PowerBuddy.MediatR.Authentication.Models
{
    public class ChangePasswordInputDTO
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
