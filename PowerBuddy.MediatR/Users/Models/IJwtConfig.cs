namespace PowerBuddy.MediatR.Users.Models
{
    public interface IJwtConfig
    {
        public string Key { get; }
        public string Issuer { get; }
    }
}
