﻿using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
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
using PowerBuddy.App.Commands.Authentication.Exceptions;
using PowerBuddy.App.Commands.Authentication.Models;
using PowerBuddy.App.Commands.Emails;
using PowerBuddy.App.Queries.Authentication;
using PowerBuddy.App.Queries.Authentication.Models;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;

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
        [ProducesResponseType(typeof(AuthenticationResultDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> LoginUser(LoginModelDTO loginModel)
        {
            try
            {
                var loginOneOf = await _mediator.Send(new LoginUserQuery(loginModel));

                return loginOneOf.Match<IActionResult>(Ok,
                    UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))),
                    EmailNotConfirmed => BadRequest(Errors.Create(nameof(EmailNotConfirmed), EmailNotConfirmed.UserId)),
                    AccountLockout => Conflict(Errors.Create(nameof(AccountLockout))),
                    InvalidCredentials => BadRequest(Errors.Create(nameof(InvalidCredentials))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Code = nameof(ValidationException), ex.Message });
            }
        }

        [HttpPost("Login/Facebook")]
        [ProducesResponseType(typeof(AuthenticationResultDTO), StatusCodes.Status200OK)]
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
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                var authResultOneOf = await _mediator.Send(new RegisterUserCommand(userDTO));

                if (authResultOneOf.AsT0 != null)
                {
                   await _mediator.Send(new SendConfirmEmailCommand(authResultOneOf.AsT0.UserId));
                }

                return authResultOneOf.Match<IActionResult>(Ok,
                    EmailOrUserNameInUse => Conflict(Errors.Create(nameof(EmailOrUserNameInUse))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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

                return result.Match<IActionResult>(Ok,
                    RefreshTokenNotFound =>
                        BadRequest(Errors.Create(nameof(RefreshTokenNotFound), RefreshTokenNotFound.Message)),
                    InvalidRefreshToken =>
                        BadRequest(Errors.Create(nameof(InvalidRefreshToken), InvalidRefreshToken.Message)));

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ResetPassword/Token/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordViaEmail(string userId, [FromBody] ChangePasswordInputDTO changePasswordInputDTO)
        {
            try
            {
                var result = await _mediator.Send(new ResetPasswordCommand(userId, changePasswordInputDTO));

                return result.Match<IActionResult>(Ok,
                    UserNotFound =>
                        BadRequest(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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

                return result.Match<IActionResult>(Ok,
                    UserNotFound =>
                        NotFound(Errors.Create(nameof(UserNotFound))),
                    InvalidCredentials => BadRequest(Errors.Create(nameof(InvalidCredentials))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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

                return result.Match<IActionResult>(Ok,
                    UserNotFound =>
                        NotFound(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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

                return result.Match<IActionResult>(Ok,
                    UserNotFound =>
                        NotFound(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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

                return result.Match<IActionResult>(Ok,
                    UserNotFound =>
                        NotFound(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
