using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBuddy.SmsService.Models
{
    public interface ITwilioSettings
    {
        public string VerificationServiceSID { get; }
    }
}
