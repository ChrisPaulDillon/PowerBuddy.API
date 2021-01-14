using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Emails.Commands;
using PowerBuddy.MediatR.Users.Querys;
using PowerBuddy.Services.Account;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;
        private readonly string _userId;

        public UserController(IMediator mediator, IAccountService accountService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _accountService = accountService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Profile/{userName}")]
        [ProducesResponseType(typeof(PublicUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicUserProfile(string userName)
        {
            try
            {
                var user = await _mediator.Send(new GetPublicUserProfileByUsernameQuery(userName)).ConfigureAwait(false);
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(PublicUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllActiveUserProfiles()
        {
            try
            {
                var userProfiles = await _mediator.Send(new GetAllActivePublicProfilesQuery(_userId)).ConfigureAwait(false);
                return Ok(userProfiles);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("ResetPassword/{emailAddress}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendPasswordReset(string emailAddress)
        {
            try
            {
                var userCount = await _mediator.Send(new SendPasswordResetCommand(emailAddress)).ConfigureAwait(false);
                return Ok(userCount);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
