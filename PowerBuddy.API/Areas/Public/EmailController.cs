using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Emails.Commands;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public EmailController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("ResetPassword/{emailAddress}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendPasswordReset(string emailAddress)
        {
            try
            {
                var userCount = await _mediator.Send(new SendPasswordResetCommand(emailAddress));
                return Ok(userCount);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ConfirmEmail/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendConfirmationEmail(string userId)
        {
            try
            {
                var result = await _mediator.Send(new SendConfirmEmailCommand(userId));
                return Ok(result);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
