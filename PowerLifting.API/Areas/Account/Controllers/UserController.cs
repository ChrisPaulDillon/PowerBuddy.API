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

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;

        public UserController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ApiResponse<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            try
            {
                var token = await _service.User.LoginUser(loginModel);
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
                var user = await _service.User.GetUserProfile(userId);
                if (user != null)
                {
                    user.UserSetting = await _service.UserSetting.GetUserSettingsByUserId(userId);
                }
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
                await _service.User.RegisterUser(userDTO);
                var user = await _userManager.FindByEmailAsync(userDTO.Email);
                if (user != null)
                {
                    var exercisesInSport = await _service.Exercise.GetAllExercisesBySport(userDTO.SportType);
                    await _service.LiftingStat.CreateLiftingStatsByAthleteType(user.Id, exercisesInSport);
                }
                return Ok(Responses.Success());
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

        [HttpGet("Settings/{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserSettings(string userId)
        {
            try
            {
                return NoContent();
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
