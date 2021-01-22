
namespace PowerBuddy.AuthenticationService.Configuration
{
    public class JwtConfig : IJwtConfig
    {
        public string Key { get; }
        public string Issuer { get; }

        public JwtConfig(string key, string issuer)
        {
            Key = key;
            Issuer = issuer;
        }
    }
}
