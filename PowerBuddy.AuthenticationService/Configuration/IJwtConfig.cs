using System;

namespace PowerBuddy.AuthenticationService.Configuration
{
    public interface IJwtConfig
    {
        public string Key { get; }
        public string Issuer { get; }
        public TimeSpan LifeTime { get; }
    }
}
