using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Public;
using PowerLifting.MediatR.Users.CommandHandler.Public;
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

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ApiResponse<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            try
            {
                var token = await _mediator.Send(new LoginUserQuery(loginModel)).ConfigureAwait(false);
                return Ok(Responses.Success(token));
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("Profile")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLoggedInUsersProfile()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var user = await _mediator.Send(new GetUserProfileQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(user));
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(ApiResponse<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                var result = await _mediator.Send(new RegisterUserCommand(userDTO)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (EmailOrUserNameInUseException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }
    }
}
