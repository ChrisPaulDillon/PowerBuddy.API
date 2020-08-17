﻿using System.Collections.Generic;
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
    [Area("Account")]
    public class FriendsListController : ControllerBase
    {
        private readonly IMediator _mediator;
        private string _userId;

        public FriendsListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Request/{friendUserId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SendFriendRequest(string friendUserId)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
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
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RespondToFriendsRequest(int friendsListId, bool acceptRequest)
        {
            try
            {
                string _userId = "00dffc28-fb73-4edb-a44e-1ee1c3354b0d";
                //_userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new RespondToFriendRequestCommand(friendsListId, acceptRequest, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserFriendsList()
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
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
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<FriendRequestDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUserPendingFriendRequests()
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var friendRequests = await _mediator.Send(new GetAllPendingFriendRequestsQuery(_userId)).ConfigureAwait(false);
                return Ok(Responses.Success(friendRequests));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }
    }
}