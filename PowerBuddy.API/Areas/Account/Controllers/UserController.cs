using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Areas.Account.Models;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Emails.Commands;
using PowerBuddy.MediatR.Users.Commands;
using PowerBuddy.MediatR.Users.Commands.Account;
using PowerBuddy.MediatR.Users.Commands.PowerBuddy.MediatR.Users.Querys;
using PowerBuddy.MediatR.Users.Models;
using PowerBuddy.MediatR.Users.Querys;

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
                var result = await _mediator.Send(new EditProfileCommand(editProfileDTO, _userId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("UpdatePassword")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePassword([FromBody] ChangePasswordInputGuiDTO changePasswordInputDTO)
        {
            try
            {
                var result  = await _mediator.Send(new UpdatePasswordCommand(changePasswordInputDTO, _userId));
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
