using MediatR;
using PowerLifting.Data.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.Notifications.Command.Admin
{
    public class CreateNotificationCommand : IRequest<NotificationDTO>
    {
        public NotificationDTO NotificationDTO { get; }
        public string UserId { get; }
        public CreateNotificationCommand(NotificationDTO notificationDTO, string userId)
        {
            NotificationDTO = notificationDTO;
            UserId = userId;
        }
    }
}
