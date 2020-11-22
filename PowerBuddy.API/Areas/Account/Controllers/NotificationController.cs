﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Notifications.Querys.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public NotificationController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotificationInteractionDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUserNotifications()
        {
            try
            {
                var notifications = await _mediator.Send(new GetUserNotificationsQuery(_userId)).ConfigureAwait(false);
                return Ok(notifications);
            }
            catch (InvalidCredentialsException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}