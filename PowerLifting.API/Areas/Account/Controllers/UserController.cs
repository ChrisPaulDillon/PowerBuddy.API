﻿using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Extensions;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Account;
using PowerLifting.MediatR.Users.Command.Public;
using PowerLifting.MediatR.Users.CommandHandler.Public;
using PowerLifting.MediatR.Users.Models;
using PowerLifting.MediatR.Users.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
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
        public async Task<IActionResult> LoginUser(LoginModelDTO loginModel)
        {
            try
            {
                var userLoggedInProfile = await _mediator.Send(new LoginUserQuery(loginModel)).ConfigureAwait(false);
                return Ok(userLoggedInProfile);
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
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
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
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
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
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
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
