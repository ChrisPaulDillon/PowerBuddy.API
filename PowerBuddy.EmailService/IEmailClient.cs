using System.Threading.Tasks;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.EmailService
{
    public interface IEmailClient
    {
        public Task SendEmailAsync(EmailMessage message);
    }
}
