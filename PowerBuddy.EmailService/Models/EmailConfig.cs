namespace PowerBuddy.EmailService.Models
{
    internal class EmailConfig : IEmailConfig
    {
        public string Host { get; }
        public int Port { get; }
        public string UserName { get; }
        public string Password { get; }

        public EmailConfig(string host, int port, string userName, string password)
        {
            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
        }
    }
}
