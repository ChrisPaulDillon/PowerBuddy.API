﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Querys.Public;

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
        [ProducesResponseType(typeof(IEnumerable<LiftFeedDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLiftFeedByUsername(string userName)
        {
            var userId = User.Claims.First(x => x.Type == "UserID").Value;
            var liftFeedCollection = await _mediator.Send(new GetLiftingStatFeedForUserQuery(userName, userId)).ConfigureAwait(false);
            return Ok(liftFeedCollection);
        }
    }
}
