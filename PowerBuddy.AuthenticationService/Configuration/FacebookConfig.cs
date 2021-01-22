namespace PowerBuddy.AuthenticationService.Configuration
{
    public class FacebookConfig : IFacebookConfig
    {
        public string AppId { get; }
        public string AppSecret { get; }

        public FacebookConfig(string appId, string appSecret)
        {
            AppId = appId;
            AppSecret = appSecret;
        }
    }
}
