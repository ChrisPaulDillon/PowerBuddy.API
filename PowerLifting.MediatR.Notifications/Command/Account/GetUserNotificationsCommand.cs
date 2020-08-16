using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.Notifications.Command.Account
{
    public class GetUserNotificationsCommand : IRequest<IEnumerable<NotificationInteractionDTO>>
    {
        public string UserId { get; }
        public GetUserNotificationsCommand(string userId)
        {
            UserId = userId;
        }
    }
}
