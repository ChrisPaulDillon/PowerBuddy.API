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
using PowerBuddy.App.Commands.Authentication;
using PowerBuddy.App.Commands.Authentication.Models;
using PowerBuddy.App.Commands.Emails;
using PowerBuddy.App.Queries.Authentication;
using PowerBuddy.App.Queries.Authentication.Models;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.Data.Requests.Users;

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
        [ProducesResponseType(typeof(AuthenticationResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginUser(LoginRequestModel loginModel)
        {
            var loginOneOf = await _mediator.Send(new LoginUserQuery(loginModel));

            return loginOneOf.Match<IActionResult>(Ok,
                UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))),
                EmailNotConfirmed => BadRequest(Errors.Create(nameof(EmailNotConfirmed), EmailNotConfirmed.UserId)),
                AccountLockout => Conflict(Errors.Create(nameof(AccountLockout))),
                InvalidCredentials => BadRequest(Errors.Create(nameof(InvalidCredentials))));
        }

        [HttpPost("Login/Facebook")]
        [ProducesResponseType(typeof(AuthenticationResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginUserWithFacebook([FromBody] FacebookAuthRequest facebookAuthRequest)
        {
            try
            {
                var userLoggedInProfile = await _mediator.Send(new LoginWithFacebookQuery(facebookAuthRequest.AccessToken));
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
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest userDto)
        {

            var authResultOneOf = await _mediator.Send(new RegisterUserCommand(userDto));

            return authResultOneOf.Match<IActionResult>(
                Result =>
                {
                    _mediator.Send(new SendConfirmEmailCommand(authResultOneOf.AsT0.UserId));
                    return Ok(Result);
                },
                EmailOrUserNameInUse => Conflict(Errors.Create(nameof(EmailOrUserNameInUse))));
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
            var result = await _mediator.Send(new RefreshTokenCommand(refreshTokenRequest.RefreshToken));

            return result.Match<IActionResult>(Ok,
                RefreshTokenNotFound =>
                    BadRequest(Errors.Create(nameof(RefreshTokenNotFound), RefreshTokenNotFound.Message)),
                InvalidRefreshToken =>
                    BadRequest(Errors.Create(nameof(InvalidRefreshToken), InvalidRefreshToken.Message)));
        }

        [HttpPut("UpdatePassword")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            var result = await _mediator.Send(new UpdatePasswordCommand(changePasswordRequest, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))),
                InvalidCredentials => BadRequest(Errors.Create(nameof(InvalidCredentials))));
        }

        [HttpPost("Email/Accept/ResetPassword/Token/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ResetPasswordViaEmail(string userId, [FromBody] ResetPasswordTokenRequest resetPasswordTokenRequest)
        {
	        var result = await _mediator.Send(new ResetPasswordViaEmailCommand(resetPasswordTokenRequest, userId));

	        return result.Match<IActionResult>(
		        Result => Ok(Result),
		        UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPost("Email/Accept/ConfirmEmail/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> VerifyEmail(string userId, [FromBody] ResetPasswordTokenRequest token)
        {
            var result = await _mediator.Send(new AcceptEmailConfirmationCommand(userId, token.Token));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPost("Sms/Accept/ConfirmSms")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AcceptSmsVerification([FromBody] PhoneNumberCodeInputDto input)
        {
            var result = await _mediator.Send(new AcceptSmsVerificationCommand(input.PhoneNumber, input.Code, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))));
        }
    }
}
