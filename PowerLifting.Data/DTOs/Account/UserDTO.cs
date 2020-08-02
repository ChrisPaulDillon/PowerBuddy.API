﻿using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.Data.DTOs.Account
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LiftingStatId { get; set; }
        public string SportType { get; set; }
        public UserSettingDTO UserSetting { get; set; }
    }
}