using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Service;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.API.API.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class AccountController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly UserManager<User> _userManager;

        public AccountController(IServiceWrapper service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ApiResponse<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            try
            {
                var token = await _service.User.LoginUser(loginModel);
                return Ok(Responses.Success(token));
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
        public async Task<IActionResult> GetLoggedInUsersProfile()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var user = await _service.User.GetUserProfile(userId);
                user.UserSetting = await _service.UserSetting.GetUserSettingsByUserId(userId);
                return Ok(Responses.Success(user));
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
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO userDTO)
        {
            try
            {
                await _service.User.RegisterUser(userDTO);
                var user = await _userManager.FindByEmailAsync(userDTO.Email);

                var exercisesInSport = await _service.Exercise.GetAllExercisesBySport(userDTO.SportType);
                await _service.LiftingStat.CreateLiftingStatsByAthleteType(user.Id, exercisesInSport);

                return Ok(Responses.Success(userDTO));
            }
            catch (EmailInUseException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateUser(int id, [FromBody] UserDTO user)
        {
            try
            {
                _service.User.UpdateUser(user);
                return NoContent();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _service.User.DeleteUser(id);
                return NoContent();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("Settings/{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetUserSettings(string userId)
        {
            try
            {
                return NoContent();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
