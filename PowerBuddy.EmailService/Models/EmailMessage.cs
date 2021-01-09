using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace PowerBuddy.EmailService.Models
{
    public class EmailMessage
    {
        public List<MailboxAddress> To { get; }
        public string Subject { get; }
        public string Content { get; }

        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
        }
    }
}
