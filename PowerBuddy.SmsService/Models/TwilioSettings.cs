
namespace PowerBuddy.SmsService.Models
{
    public class TwilioSettings : ITwilioSettings
    {
        public string VerificationServiceSID { get; }

        public TwilioSettings(string verificationServiceSid)
        {
            VerificationServiceSID = verificationServiceSid;
        }
    }
}
