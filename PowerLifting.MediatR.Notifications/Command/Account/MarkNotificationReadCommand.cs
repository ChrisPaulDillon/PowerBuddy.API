using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.Notifications.Command.Account
{
    public class MarkNotificationReadCommand : IRequest<bool>
    {
        public int NotificationInteractionId { get; }
        public string UserId { get; }
        public MarkNotificationReadCommand(int notificationInteractionId, string userId)
        {
            NotificationInteractionId = notificationInteractionId;
            UserId = userId;
        }
    }
}
