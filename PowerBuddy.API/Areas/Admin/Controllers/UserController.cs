﻿using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Users;
using PowerBuddy.App.Queries.Users;
using PowerBuddy.Data.Dtos.Users;

namespace PowerBuddy.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Admin")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public UserController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet]
        [ProducesResponseType(typeof(AdminUserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAdminUsers()
        {
            var users = await _mediator.Send(new GetAllUsersByAdminQuery(_userId));
            return Ok(users);
        }

        [HttpPut("{bannedUserId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BanUser(string bannedUserId)
        {
            var result = await _mediator.Send(new BanUserCommand(bannedUserId, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))));
        }
    }
}
