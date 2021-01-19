using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerBuddy.API.Areas.Account.Models
{
    public class PhoneNumberCodeInputDTO : PhoneNumberInputDTO
    {
        public string Code { get; set; }
    }
}
