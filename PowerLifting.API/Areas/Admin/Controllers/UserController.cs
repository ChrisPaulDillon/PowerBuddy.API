using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private string _userId;

        public UserController(IServiceWrapper service, IHttpContextAccessor accessor)
        {
            _service = service;
            _userId = accessor.HttpContext.User.Claims.First(x => x.Type == "UserID").Value;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<AdminUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAdminUsers()
        {
            var users = await _service.User.GetAllAdminUsers();
            return Ok(Responses.Success(users));
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BanUser(string userId)
        {
            try
            {
                var result = await _service.User.BanUser(userId, _userId);
                return Ok(Responses.Success(result));
            }
            catch (UserValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
