using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Areas.Account.Models;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Authentication.Models;
using PowerBuddy.MediatR.Authentication.Querys;
using PowerBuddy.MediatR.Emails.Commands;
using PowerBuddy.MediatR.Users.Commands;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public AuthController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserLoggedInDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginUser(LoginModelDTO loginModel)
        {
            try
            {
                var userLoggedInProfile = await _mediator.Send(new LoginUserQuery(loginModel));
                return Ok(userLoggedInProfile);
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(new { Code = nameof(InvalidCredentialsException), ex.Message });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { Code = nameof(UserNotFoundException), ex.Message });
            }
            catch (AccountLockoutException ex)
            {
                return Conflict(new { Code = nameof(AccountLockoutException), ex.Message });
            }
            catch (EmailNotConfirmedException ex)
            {
                return BadRequest(new { Code = nameof(EmailNotConfirmedException), ex.Message });
            }
        }

        [HttpPost("Login/Facebook")]
        [ProducesResponseType(typeof(UserLoggedInDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginUserWithFacebook([FromBody] FacebookAuthRequest facebookAuthRequest)
        {
            var userLoggedInProfile = await _mediator.Send(new LoginWithFacebookQuery(facebookAuthRequest.AccessToken));
            return Ok(userLoggedInProfile);
        }


        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                var userId = await _mediator.Send(new RegisterUserCommand(userDTO)).ConfigureAwait(false);

                if (userId != null)
                {
                    await _mediator.Send(new SendConfirmEmailCommand(userId));
                }

                return Ok(userId);
            }
            catch (EmailOrUserNameInUseException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPost("ChangePassword/Token/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordViaEmail(string userId, [FromBody] ChangePasswordInputDTO changePasswordInputDTO)
        {
            try
            {
                var result = await _mediator.Send(new ResetPasswordCommand(userId, changePasswordInputDTO)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(new { Code = nameof(UserNotFoundException), ex.Message });
            }
        }

        [HttpPost("VerifyEmail/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VerifyEmail(string userId, [FromBody] ChangePasswordInputDTO token)
        {
            try
            {
                var result = await _mediator.Send(new VerifyEmailCommand(userId, token.Token));
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(new { Code = nameof(UserNotFoundException), ex.Message });
            }
        }


        [HttpPost("Sms/RequestVerification")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestSmsVerification([FromBody] PhoneNumberInputDTO phoneNumber)
        {
            try
            {
                var result = await _mediator.Send(new RequestSmsVerificationCommand(phoneNumber.PhoneNumber, _userId));
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(new { Code = nameof(UserNotFoundException), ex.Message });
            }
        }

        [HttpPost("Sms/SendVerification")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendSmsVerification([FromBody] PhoneNumberCodeInputDTO input)
        {
            try
            {
                var result = await _mediator.Send(new SendSmsVerificationCommand(input.PhoneNumber, input.Code, _userId));
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(new { Code = nameof(UserNotFoundException), ex.Message });
            }
        }
    }
}
