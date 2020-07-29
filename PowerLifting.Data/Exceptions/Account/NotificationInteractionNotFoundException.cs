using System;

namespace PowerLifting.Data.Exceptions.Account
{
    public class NotificationInteractionNotFoundException : Exception
    {
        public NotificationInteractionNotFoundException() : base("Notification Interaction not found with parameters supplied") { }
    }
}