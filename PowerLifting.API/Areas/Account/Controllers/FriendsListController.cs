using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Extensions;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
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
        private readonly string _userId;
        public FriendsListController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("Request/{friendUserId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SendFriendRequest(string friendUserId)
        {
            try
            {
                var requestSent = await _mediator.Send(new SendFriendRequestCommand(friendUserId, _userId)).ConfigureAwait(false);

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
                var result = await _mediator.Send(new RespondToFriendRequestCommand(friendsListId, acceptRequest, _userId)).ConfigureAwait(false);
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
                var result = await _mediator.Send(new GetUserFriendsListQuery(_userId)).ConfigureAwait(false);

                var friendsListExtended = new List<FriendsListExtended>();

                foreach (var x in result)
                {
                    var user = await _mediator.Send(new GetPublicUserProfileByIdQuery(_userId)).ConfigureAwait(false);
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
                var friendRequests = await _mediator.Send(new GetAllPendingFriendRequestsQuery(_userId)).ConfigureAwait(false);
                var friendRequestsExtended = new List<FriendRequestExtended>();

                foreach (var friendRequest in friendRequests)
                {
                    var user = new PublicUserDTO();
                    if (friendRequest.UserFromId != _userId)
                    {
                        user = await _mediator.Send(new GetPublicUserProfileByIdQuery(friendRequest.UserFromId))
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        user = await _mediator.Send(new GetPublicUserProfileByIdQuery(friendRequest.UserToId))
                            .ConfigureAwait(false);
                    }

                    var friendList = new FriendRequestExtended()
                    {
                        FriendRequestId = friendRequest.FriendRequestId,
                        UserId = user.UserId,
                        UserName = user.UserName
                    };
                    friendRequestsExtended.Add(friendList);
                }
                return Ok(Responses.Success(friendRequestsExtended));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}
