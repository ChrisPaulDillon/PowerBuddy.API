using System;
using System.Threading.Tasks;
using PowerBuddy.SmsService.Models;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace PowerBuddy.SmsService
{
    public class SmsClient : ISmsClient
    {
        private readonly ITwilioSettings _settings;

        public SmsClient(ITwilioSettings settings)
        {
            _settings = settings;
        }

        public async Task<string> SendPhoneNumberVerification(string phoneNumber)
        {
            try
            {
                var verification = await VerificationResource.CreateAsync(
                    to: phoneNumber,
                    channel: "sms",
                    pathServiceSid: _settings.VerificationServiceSID
                );

                return verification.Status;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public async Task<bool> VerifyPhoneNumber(string phoneNumber, string code)
        {
            try
            {
                var verification = await VerificationCheckResource.CreateAsync(
                    to: phoneNumber,
                    code: code,
                    pathServiceSid: _settings.VerificationServiceSID
                );

                if (verification.Status == "approved")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
