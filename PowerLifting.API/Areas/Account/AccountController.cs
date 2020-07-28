﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Service;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.SignalR;

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
        IHubContext<MessageHub> _messageHub;

        public AccountController(IServiceWrapper service, UserManager<User> userManager, IHubContext<MessageHub> messageHub)
        {
            _service = service;
            _userManager = userManager;
            _messageHub = messageHub;
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
                if (user != null)
                {
                    user.UserSetting = await _service.UserSetting.GetUserSettingsByUserId(userId);
                }
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
                if (user != null)
                {
                    var exercisesInSport = await _service.Exercise.GetAllExercisesBySport(userDTO.SportType);
                    await _service.LiftingStat.CreateLiftingStatsByAthleteType(user.Id, exercisesInSport);
                }
                await _messageHub.Clients.All.SendAsync("pizza", "lmfao");
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
