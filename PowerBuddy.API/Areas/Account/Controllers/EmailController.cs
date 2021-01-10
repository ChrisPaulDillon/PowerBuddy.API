using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Account;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.EmailService;
using PowerBuddy.EmailService.Models;
using PowerBuddy.MediatR.Users.Commands.Account;
using PowerBuddy.MediatR.Users.Models;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailSender _emailSender;
        private readonly string _userId;

        public EmailController(IMediator mediator, IHttpContextAccessor accessor, IEmailSender emailSender)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
            _emailSender = emailSender;
        }

        [HttpPost("ConfirmEmail")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                
                return Ok("OK");
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("ResetPassword")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword()
        {
            try
            {
                var message = new EmailMessage(new List<string>() { "chrispauldillon@live.com" }, "Test Email", "Test body");
                await _emailSender.SendEmailAsync(message);
                return Ok("OK");
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
