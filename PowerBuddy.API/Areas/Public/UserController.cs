using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Queries.Users;
using PowerBuddy.Data.Dtos.Users;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public UserController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Profile/{userName}")]
        [ProducesResponseType(typeof(PublicUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicUserProfile(string userName)
        {
            var result = await _mediator.Send(new GetPublicUserProfileByUsernameQuery(userName));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));

        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(PublicUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllActiveUserProfiles()
        {

            var userProfiles = await _mediator.Send(new GetAllActivePublicProfilesQuery(_userId));
            return Ok(userProfiles);
        }
    }
}
