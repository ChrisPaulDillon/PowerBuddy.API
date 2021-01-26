using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Public;

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
        [ProducesResponseType(typeof(IEnumerable<LiftFeedDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLiftFeedByUsername(string userName)
        {
            try
            {
                var liftFeedCollection = await _mediator.Send(new GetLiftingStatFeedForUserQuery(userName, _userId));
                return Ok(liftFeedCollection);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
