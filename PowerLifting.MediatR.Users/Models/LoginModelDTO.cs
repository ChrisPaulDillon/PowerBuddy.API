using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.Users.Models
{
    public class LoginModelDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
