using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Users;
using PowerBuddy.App.Queries.Users;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public UserController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Profile")]
        [Authorize]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLoggedInUsersProfile()
        {
            try
            {
                var userOneOf = await _mediator.Send(new GetUserProfileQuery(_userId));

                return userOneOf.Match<IActionResult>(
                    User => Ok(User),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
    
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FirstVisit")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FirstVisit([FromBody] FirstVisitDTO firstVisitDTO)
        {
            try
            {
                var result = await _mediator.Send(new CreateFirstVisitStatsCommand(firstVisitDTO, _userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Profile")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDTO editProfileDTO)
        {
            try
            {
                var result = await _mediator.Send(new EditProfileCommand(editProfileDTO, _userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
