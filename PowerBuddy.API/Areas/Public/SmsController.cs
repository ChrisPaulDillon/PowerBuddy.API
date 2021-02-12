using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Areas.Account.Models;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Sms;

namespace PowerBuddy.API.Areas.Public
{
	[Route("api/[area]/[controller]")]
	[ApiController]
	[Produces("application/json")]
	[Area("Public")]
	public class SmsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly string _userId;

		public SmsController(IMediator mediator, IHttpContextAccessor accessor)
		{
			_mediator = mediator;
			_userId = accessor.HttpContext.User.FindUserId();
		}

		[HttpPost("Send/ConfirmSms")]
		[Authorize]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> SendSmsVerification([FromBody] PhoneNumberInputDto phoneNumber)
		{
			var result = await _mediator.Send(new SendSmsVerificationCommand(phoneNumber.PhoneNumber, _userId));

			return result.Match<IActionResult>(Ok,
				UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))));
		}
	}
}
