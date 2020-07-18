using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Entity.Users.DTO;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.API.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class AccountController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly UserManager<User> _userManager;

        public AccountController(IServiceWrapper service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("Profile/{userName}")]
        [ProducesResponseType(typeof(ApiResponse<PublicUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLoggedInUsersProfile(string userName)
        {
            try
            {
                var user = await _service.User.GetPublicUserProfileByUserName(userName);
                return Ok(Responses.Success(user));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(ApiResponse<PublicUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllActiveUserProfiles()
        {
            try
            {
                var userProfiles = await _service.User.GetAllActivePublicProfiles();
                return Ok(Responses.Success(userProfiles));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
