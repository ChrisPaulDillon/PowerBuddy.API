namespace PowerBuddy.MediatR.Emails.Models
{
    public class EmailAssistant : IEmailAssistant
    {
        public string BaseUrl { get; }
        public string SiteName { get; }

        public EmailAssistant(string baseUrl, string siteName)
        {
            BaseUrl = baseUrl;
            SiteName = siteName;
        }
    }
}
