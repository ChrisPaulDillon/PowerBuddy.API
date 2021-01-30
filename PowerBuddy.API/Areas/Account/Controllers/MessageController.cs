using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PowerBuddy.SignalR;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hub;

        public MessageController(IHubContext<MessageHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _hub.Clients.All.SendAsync("testlmfao", "hi there"); //Send message to everyone who is 'plugged into' the 'testlmfao' method
            return Ok();
        }
    }
}
