using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.Account
{
    public class EditProfileDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BodyWeight { get; set; }
        public bool QuotesEnabled { get; set; }
    }
}
