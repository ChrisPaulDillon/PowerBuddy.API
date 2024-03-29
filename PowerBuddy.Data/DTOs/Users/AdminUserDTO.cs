﻿namespace PowerBuddy.Data.Dtos.Users
{
    public class AdminUserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal BodyWeight { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SportType { get; set; }
        public bool IsPublic { get; set; }
        public bool IsBanned { get; set; }
        public bool QuotesEnabled { get; set; }
    }
}
