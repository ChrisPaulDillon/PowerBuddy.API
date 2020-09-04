using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.MediatR.Users.Models
{
    public class UserLoggedInDTO 
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
