﻿using System;
namespace PowerLifting.Entity.Users.DTO
{
    public class PublicUserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string SportType { get; set; }
        public bool IsPublic { get; set; }
    }
}