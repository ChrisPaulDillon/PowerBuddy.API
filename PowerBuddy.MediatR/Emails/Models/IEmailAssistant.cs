﻿namespace PowerBuddy.MediatR.Emails.Models
{
    public interface IEmailAssistant
    {
        public string BaseUrl { get; }
        public string SiteName { get; }
    }
}
