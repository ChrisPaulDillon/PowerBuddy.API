using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Areas.Account.Models;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Commands.Authentication;
using PowerBuddy.MediatR.Commands.Authentication.Exceptions;
using PowerBuddy.MediatR.Commands.Authentication.Models;
using PowerBuddy.MediatR.Commands.Emails;
using PowerBuddy.MediatR.Queries.Authentication;
using PowerBuddy.MediatR.Queries.Authentication.Models;
using PowerBuddy.Services.Authentication.Models;

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
        [ProducesResponseType(typeof(AuthenticatedUserDTO), StatusCodes.Status200OK)]
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
            catch (ValidationException ex)
            {
                return BadRequest(new { Code = nameof(ValidationException), ex.Message });
            }
            catch (InvalidCredentialsException ex)
            {
                return BadRequest(new { Code = nameof(InvalidCredentialsException), ex.Message });
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
        [ProducesResponseType(typeof(AuthenticatedUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginUserWithFacebook([FromBody] FacebookAuthRequest facebookAuthRequest)
        {
            try
            {
                var userLoggedInProfile =
                    await _mediator.Send(new LoginWithFacebookQuery(facebookAuthRequest.AccessToken));
                return Ok(userLoggedInProfile);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(new { Code = nameof(HttpRequestException), ex.Message });
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                var authenticatedUser = await _mediator.Send(new RegisterUserCommand(userDTO));

                if (authenticatedUser != null)
                {
                    await _mediator.Send(new SendConfirmEmailCommand(authenticatedUser.User.UserId));
                }

                return Ok(authenticatedUser);
            }
            catch (EmailOrUserNameInUseException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPost("Logout/{refreshToken}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LogoutAndRevokeToken(string refreshToken)
        {
            try
            {
                var result = await _mediator.Send(new LogoutCommand(refreshToken));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            try
            {
                var result = await _mediator.Send(new RefreshTokenCommand(refreshTokenRequest.RefreshToken));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RefreshTokenNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidRefreshTokenException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ChangePassword/Token/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordViaEmail(string userId, [FromBody] ChangePasswordInputDTO changePasswordInputDTO)
        {
            try
            {
                var result = await _mediator.Send(new ResetPasswordCommand(userId, changePasswordInputDTO));
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
        [Authorize]
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
        [Authorize]
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


        [HttpPut("UpdatePassword")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePassword([FromBody] ChangePasswordInputGuiDTO changePasswordInputDTO)
        {
            try
            {
                var result = await _mediator.Send(new UpdatePasswordCommand(changePasswordInputDTO, _userId));
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { Code = nameof(UserNotFoundException), ex.Message });
            }
            catch (InvalidCredentialsException ex)
            {
                return BadRequest(new { Code = nameof(InvalidCredentialsException), ex.Message });
            }
        }
    }
}
