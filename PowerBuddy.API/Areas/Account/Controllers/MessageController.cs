using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PowerBuddy.SignalR;
using PowerBuddy.SignalR.Models;

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

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] SignalrMessage toastiBoi)
        {
            return Ok();
        }
    }
}
