using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Emails;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Send/ResetPassword/{emailAddress}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendPasswordReset(string emailAddress)
        {
            var result = await _mediator.Send(new SendPasswordResetCommand(emailAddress));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPost("Send/ConfirmEmail/{userId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendConfirmationEmail(string userId)
        {
            var result = await _mediator.Send(new SendConfirmEmailCommand(userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }
    }
}
