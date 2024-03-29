﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.LiftingStats;
using PowerBuddy.App.Queries.LiftingStats;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.LiftingStats;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightOutgoingConvertorService _weightOutputService;
        private readonly string _userId;

        public LiftingStatsController(IMediator mediator, IWeightOutgoingConvertorService weightOutputService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightOutputService = weightOutputService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatAuditDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserLiftingStats()
        {
            var liftingStats = await _mediator.Send(new GetLiftingStatsByUserIdQuery(_userId));
            return Ok(liftingStats);
        }

        [HttpGet("{exerciseId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatDetailedDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLiftingStatSummaryByExerciseId(int exerciseId)
        {
            var liftingStatOneOf = await _mediator.Send(new GetLiftingStatSummaryByExerciseIdQuery(exerciseId, _userId));

            if (liftingStatOneOf.IsT0)
            {
                liftingStatOneOf.AsT0.LiftingStats = await _weightOutputService.ConvertPersonalBests(liftingStatOneOf.AsT0.LiftingStats, _userId, null);
                liftingStatOneOf.AsT0.LifeTimeTonnage = await _weightOutputService.ConvertGenericWeight(liftingStatOneOf.AsT0.LifeTimeTonnage, _userId, null);
            }

            return liftingStatOneOf.Match<IActionResult>(Ok,
                LiftingStatNotFound => BadRequest(Errors.Create(nameof(LiftingStatNotFound))));
        }

        [HttpDelete("Audit/{liftingStatAuditId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteLiftingStatAudit(int liftingStatAuditId)
        {
            var result = await _mediator.Send(new DeleteLiftingStatAuditCommand(liftingStatAuditId, _userId));

            return result.Match<IActionResult>(
                IsDeleted => Ok(IsDeleted),
                LiftingStatNotFound => NotFound(Errors.Create(nameof(LiftingStatNotFound))),
                UserNotFound => NotFound(Errors.Create(nameof(UserNotFound))));
        }
    }
}
