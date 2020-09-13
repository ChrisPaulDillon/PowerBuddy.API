using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.MediatR.ExerciseMuscleGroups.Query.Public;
using PowerLifting.MediatR.Exercises.Query.Public;
using PowerLifting.MediatR.ExerciseTypes.Query.Public;
using PowerLifting.MediatR.LiftingStats.Query.Public;

namespace PowerLifting.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LiftingStatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<LiftFeedDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLiftFeedByUsername(string userName)
        {
            var userId = User.Claims.First(x => x.Type == "UserID").Value;
            var liftFeedCollection = await _mediator.Send(new GetLiftingStatFeedForUserQuery(userName, userId)).ConfigureAwait(false);
            return Ok(Responses.Success(liftFeedCollection));
        }
    }
}
