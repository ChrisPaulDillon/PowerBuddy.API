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

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IServiceWrapper service, SignInManager<User> signInManager)
        {
            _service = service;
            _signInManager = signInManager;
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
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLoggedInUsersProfile()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var user = await _service.User.GetUserProfile(userId);
                return Ok(Responses.Success(user));
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
