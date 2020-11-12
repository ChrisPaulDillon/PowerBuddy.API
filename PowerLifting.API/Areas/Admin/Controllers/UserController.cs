using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Extensions;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Commands.Admin;
using PowerLifting.MediatR.Users.Querys.Admin;

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
        private readonly string _userId;

        public UserController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet]
        [ProducesResponseType(typeof(AdminUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAdminUsers()
        {
            var users = await _mediator.Send(new GetAllUsersByAdminQuery(_userId)).ConfigureAwait(false);
            return Ok(users);
        }

        [HttpPut("{bannedUserId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BanUser(string bannedUserId)
        {
            try
            {
                var result = await _mediator.Send(new BanUserCommand(bannedUserId, _userId)).ConfigureAwait(false);
                return Ok(result);
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
