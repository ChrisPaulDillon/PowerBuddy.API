using System.Net.Mail;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.EmailService;
using PowerBuddy.EmailService.Models;
using PowerBuddy.MediatR.Users.Commands.Account;
using PowerBuddy.MediatR.Users.Commands.Public;
using PowerBuddy.MediatR.Users.Models;
using PowerBuddy.MediatR.Users.Querys.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly EmailConfig _emailSender;
        private readonly string _userId;

        public UserController(IMediator mediator, IHttpContextAccessor accessor, EmailConfig emailSender)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
            _emailSender = emailSender;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserLoggedInDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser(LoginModelDTO loginModel)
        {
            try
            {
                var userLoggedInProfile = await _mediator.Send(new LoginUserQuery(loginModel)).ConfigureAwait(false);
                return Ok(userLoggedInProfile);
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Profile")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLoggedInUsersProfile()
        {
            try
            {
                var user = await _mediator.Send(new GetUserProfileQuery(_userId)).ConfigureAwait(false);
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                var result = await _mediator.Send(new RegisterUserCommand(userDTO)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (EmailOrUserNameInUseException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("FirstVisit")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FirstVisit([FromBody] FirstVisitDTO firstVisitDTO)
        {
            try
            {
                var result = await _mediator.Send(new CreateFirstVisitStatsCommand(firstVisitDTO, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("Profile")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDTO editProfileDTO)
        {
            try
            {
                var result = await _mediator.Send(new EditProfileCommand(editProfileDTO, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("ResetPassword")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword()
        {
            try
            {
                var message = new EmailMessage(new string[] { "chrispauldillon@live.com"}, "Test Email", "Test body" );
               // await _emailSender.SendEmailAsync(message);
                return Ok("OK");
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
