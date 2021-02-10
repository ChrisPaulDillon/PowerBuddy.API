using System.Linq;
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
using PowerBuddy.Data.Dtos.Account;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.FileHandlerService.Exceptions;

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
        private readonly HttpRequest _request;

        public UserController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
            _request = accessor.HttpContext.Request;
        }

        [Authorize]
        [HttpGet("Profile")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLoggedInUsersProfile()
        {
            var userOneOf = await _mediator.Send(new GetUserProfileQuery(_userId));

            return userOneOf.Match<IActionResult>(
                User => Ok(User),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPost("FirstVisit")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FirstVisit([FromBody] FirstVisitDto firstVisitDto)
        {
            var result = await _mediator.Send(new CreateFirstVisitStatsCommand(firstVisitDto, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPut("Profile")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDto editProfileDto)
        {
            var result = await _mediator.Send(new EditProfileCommand(editProfileDto, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPost("Image")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadProfileImage([FromForm] IFormFile file)
        {
            try
            {
                //var imageFile = _request.Form.Files.FirstOrDefault();

                var userId = "c0f79347-d5eb-48b6-a4d7-de8e3f12a3cc";
                var result = await _mediator.Send(new UploadProfileImageCommand(file, userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
            }
            catch (BadFileException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
