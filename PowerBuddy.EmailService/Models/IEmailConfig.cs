namespace PowerBuddy.EmailService.Models
{
    public interface IEmailConfig
    {
        public string Host { get; }
        public int Port { get; }
        public string UserName { get; }
        public string Password { get; }
    }
}
