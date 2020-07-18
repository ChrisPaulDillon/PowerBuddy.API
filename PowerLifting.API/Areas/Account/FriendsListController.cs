using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Entity.Account.DTOs;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Exceptions;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.API.API.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class FriendsListController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly UserManager<User> _userManager;
        private string _userId;

        public FriendsListController(IServiceWrapper service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpPost("Request")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SendFriendRequest(FriendsListDTO friendsList)
        {
            try
            {
                var result = await _service.FriendsList.SendFriendsRequest(friendsList);
                return Ok(Responses.Success(result));
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
        public async Task<IActionResult> RespondToFriendsQuest(int friendsListId, bool acceptRequest)
        {
            try
            {
                string _userId = "00dffc28-fb73-4edb-a44e-1ee1c3354b0d";
                //_userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _service.FriendsList.RespondToFriendRequest(friendsListId, acceptRequest, _userId);
                return Ok(Responses.Success(result));
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserFriendsList()
        {
            try
            {
                string _userId = "f595080c-8484-4d60-99e4-3a32f75702f7";
                //_userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = (await _service.FriendsList.GetUsersFriendList(_userId)).ToList();

                var friendsListExtended = new List<FriendsListExtended>();

                foreach (var x in result)
                {
                    var friendList = new FriendsListExtended()
                    {
                        FriendsListAssocId = x.FriendsListAssocId,
                        OtherUserId = x.OtherUserId,
                        UserName = (await _service.User.GetPublicUserProfileById(x.OtherUserId)).UserName
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
    }
}
