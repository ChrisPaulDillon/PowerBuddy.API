namespace PowerBuddy.AuthenticationService
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string userId);
    }
}
