
using System;

namespace PowerBuddy.AuthenticationService.Configuration
{
    public class JwtConfig : IJwtConfig
    {
        public string Key { get; }
        public string Issuer { get; }
        public TimeSpan LifeTime { get; }

        public JwtConfig(string key, string issuer, TimeSpan lifeTime)
        {
            Key = key;
            Issuer = issuer;
            LifeTime = lifeTime;
        }
    }
}
