using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Admin;
using PowerLifting.MediatR.Users.Query.Admin;

namespace PowerLifting.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<AdminUserDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAdminUsers()
        {
            var userId = User.Claims.First(x => x.Type == "UserID").Value;
            var users = await _mediator.Send(new GetAllUsersByAdminQuery(userId)).ConfigureAwait(false);
            return Ok(Responses.Success(users));
        }

        [HttpPut("{bannedUserId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BanUser(string bannedUserId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new BanUserCommand(bannedUserId, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
