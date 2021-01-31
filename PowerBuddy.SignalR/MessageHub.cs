using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using PowerBuddy.SignalR.Models;
using PowerBuddy.SignalR.Util;

namespace PowerBuddy.SignalR
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAllClients(SignalrMessage message)
        {
            await Clients.All.SendAsync(SignalRConstants.MESSAGE_METHOD_ALL, message); //Send message to everyone who is 'plugged into' the 'testlmfao' method
        }
    }
}
