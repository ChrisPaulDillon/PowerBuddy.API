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
        private readonly string _userId;

        public UserController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Profile/{userName}")]
        [ProducesResponseType(typeof(PublicUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicUserProfile(string userName)
        {
            try
            {
                var user = await _mediator.Send(new GetPublicUserProfileByUsernameQuery(userName));
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
                var userProfiles = await _mediator.Send(new GetAllActivePublicProfilesQuery(_userId));
                return Ok(userProfiles);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
