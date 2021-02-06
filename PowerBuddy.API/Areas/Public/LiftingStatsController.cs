using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Queries.LiftingStats;
using PowerBuddy.Data.Dtos.LiftingStats;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public LiftingStatsController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(IEnumerable<LiftFeedDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLiftFeedByUsername(string userName)
        {
            try
            {
                var result = await _mediator.Send(new GetLiftingStatFeedForUserQuery(userName, _userId));
                
                return result.Match<IActionResult>(
                    Ok,
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
