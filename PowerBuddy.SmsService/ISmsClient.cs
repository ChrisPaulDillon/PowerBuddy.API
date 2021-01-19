using System.Threading.Tasks;

namespace PowerBuddy.SmsService
{
    public interface ISmsClient
    {
        Task<string> SendPhoneNumberVerification(string phoneNumber);
        Task<bool> VerifyPhoneNumber(string phoneNumber, string code);
    }
}
