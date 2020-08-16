using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Notifications.Command.Account;

namespace PowerLifting.API.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserNotifications()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var notifications = await _mediator.Send(new GetUserNotificationsQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(notifications));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
