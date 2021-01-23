namespace PowerBuddy.API.Areas.Account.Models
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
