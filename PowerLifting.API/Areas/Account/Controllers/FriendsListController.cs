using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.FriendsLists.Command.Account;
using PowerLifting.MediatR.FriendsLists.Query.Account;
using PowerLifting.MediatR.Users.Query.Public;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class FriendsListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendsListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Request/{friendUserId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SendFriendRequest(string friendUserId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var requestSent = await _mediator.Send(new SendFriendRequestCommand(friendUserId, userId)).ConfigureAwait(false);

                //TODO create notification
                return Ok(Responses.Success(requestSent));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPost("Response/{friendsListId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RespondToFriendsRequest(int friendsListId, bool acceptRequest)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new RespondToFriendRequestCommand(friendsListId, acceptRequest, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserFriendsList()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new GetUserFriendsListQuery(userId)).ConfigureAwait(false);

                var friendsListExtended = new List<FriendsListExtended>();

                foreach (var x in result)
                {
                    var user = await _mediator.Send(new GetPublicUserProfileByIdQuery(userId)).ConfigureAwait(false);
                    var friendList = new FriendsListExtended()
                    {
                        FriendsListAssocId = x.FriendsListAssocId,
                        OtherUserId = x.OtherUserId,
                        UserName = user.UserName
                    };
                    friendsListExtended.Add(friendList);
                }
                return Ok(Responses.Success(friendsListExtended));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("Pending")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<FriendRequestDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUserPendingFriendRequests()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var friendRequests = await _mediator.Send(new GetAllPendingFriendRequestsQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(friendRequests));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
