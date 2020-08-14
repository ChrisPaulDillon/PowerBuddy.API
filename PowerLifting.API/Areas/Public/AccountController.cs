using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Profile/{userName}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<PublicUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicUserProfile(string userName)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var user = await _service.User.GetPublicUserProfileByUserName(userName);
                if (user != null)
                {
                    var friendRequest = await _service.FriendsList.GetPendingFriendRequest(user.UserId, userId);
                    var userExtended = new PublicUserExtendedDTO()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        IsPublic = user.IsPublic,
                        PendingFriendRequest = friendRequest != null,
                        SportType = user.SportType
                    };
                    return Ok(Responses.Success(userExtended));
                }
                return NotFound();
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
