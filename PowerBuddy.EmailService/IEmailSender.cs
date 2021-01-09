using System.Threading.Tasks;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.EmailService
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(EmailMessage message);
    }
}
