using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Exercises.Query.Admin;
using PowerLifting.MediatR.Notifications.Command.Admin;

namespace PowerLifting.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<NotificationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateNotification(NotificationDTO notificationDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var notification = await _mediator.Send(new CreateNotificationCommand(notificationDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(notification));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
