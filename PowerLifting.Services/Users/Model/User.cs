using System;
using System.Collections.Generic;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;

namespace Powerlifting.Services.Users.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual LiftingStat LiftingStats { get; set; }
        public ICollection<ProgramLog> ProgramLogs { get; set; }

    }
}
