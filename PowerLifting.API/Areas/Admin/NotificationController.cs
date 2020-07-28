using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Service;
using PowerLifting.Service.Users.Exceptions;

namespace PowerLifting.API.API.Areas.Admin
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public NotificationController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<NotificationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateNotification(NotificationDTO notificationDTO)
        {
            try
            {
                //var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var notification = await _service.Notification.CreateNotification(notificationDTO);
                return Ok(Responses.Success(notification));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
