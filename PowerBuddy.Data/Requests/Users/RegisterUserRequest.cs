﻿namespace PowerBuddy.Data.Requests.Users
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SportType { get; set; }
    }
}