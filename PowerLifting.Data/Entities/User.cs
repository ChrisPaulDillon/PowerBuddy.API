﻿using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Data.Entities
{
    public partial class User : IdentityUser
    {
        public int LiftingStatId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GenderId { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsBanned { get; set; }
        public string SportType { get; set; }
        public bool FirstVisit { get; set; }
        public int? MemberStatusId { get; set; }
    }
}