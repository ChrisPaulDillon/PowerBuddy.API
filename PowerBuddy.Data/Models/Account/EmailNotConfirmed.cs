﻿using System;

namespace PowerBuddy.Data.Models.Account
{
    public readonly struct EmailNotConfirmed 
    {
        public string UserId { get; }

        public EmailNotConfirmed(string userId)
        {
            UserId = userId;
        }
    }
}
