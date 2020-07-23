using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PowerLifting.SignalR
{
    public class MessageHub : Hub
    {
        public MessageHub()
        {
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
