using System.Collections.Generic;
using MimeKit;

namespace PowerBuddy.EmailService.Models
{
    public class EmailMessage
    {
        public IEnumerable<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            Subject = subject;
            Content = content;
        }
    }
}
