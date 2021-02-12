namespace PowerBuddy.App.Commands.Authentication.Models
{
    public class ResetPasswordTokenRequest
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
