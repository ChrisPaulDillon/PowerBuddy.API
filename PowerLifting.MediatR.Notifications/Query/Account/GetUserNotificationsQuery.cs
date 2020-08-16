using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.MediatR.Notifications.Command.Account
{
    public class GetUserNotificationsQuery : IRequest<IEnumerable<NotificationInteractionDTO>>
    {
        public string UserId { get; }
        public GetUserNotificationsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
