﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Models;
using PowerBuddy.App.Queries.Metrics;
using PowerBuddy.Data.Dtos.Users;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class MetricController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MetricController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Landing")]
        [ProducesResponseType(typeof(PublicUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLandingPageMetrics()
        {
            var metrics = await _mediator.Send(new GetLandingPageMetricsQuery());
            return Ok(metrics);
        }
    }
}
