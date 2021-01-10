using System.Threading.Tasks;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.EmailService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailMessage message);
    }
}
