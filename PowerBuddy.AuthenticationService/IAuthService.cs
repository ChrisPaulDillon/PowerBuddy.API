namespace PowerBuddy.AuthenticationService
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string userId, string userName, bool usingMetric, bool firstVisit, int memberStatusId);
    }
}
