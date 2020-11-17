using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class NotificationInteractionNotFoundException : Exception
    {
        public NotificationInteractionNotFoundException() : base("Notification Interaction not found with parameters supplied") { }
    }
}