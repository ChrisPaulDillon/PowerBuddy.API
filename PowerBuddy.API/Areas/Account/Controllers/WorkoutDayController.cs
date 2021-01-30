using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.MediatR.Commands.WorkoutDays;
using PowerBuddy.MediatR.Commands.WorkoutDays.Models;
using PowerBuddy.MediatR.Queries.WorkoutDays;
using PowerBuddy.Services.Weights;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize]
    public class WorkoutDayController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightInsertConvertorService _weightInsertService;
        private readonly IWeightOutgoingConvertorService _weightOutputService;
        private readonly string _userId;

        public WorkoutDayController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IWeightOutgoingConvertorService weightOutputService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _weightOutputService = weightOutputService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("{workoutDayId:int}")]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutDayById(int workoutDayId)
        {
            try
            {
                var workoutDay = await _mediator.Send(new GetWorkoutDayByIdQuery(workoutDayId, _userId));
                workoutDay = await _weightOutputService.ConvertWorkoutDay(workoutDay, _userId, null);
                return Ok(workoutDay);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateWorkoutDay([FromBody] CreateWorkoutDayOptions createWorkoutOptions)
        {
            try
            {
                var workoutDay = await _mediator.Send(new CreateWorkoutDayCommand(createWorkoutOptions, _userId));

                return Ok(workoutDay);
            }
            catch (WorkoutDayAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Today")]
        [ProducesResponseType(typeof(WorkoutDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWorkoutDayIdByDate()
        {
            try
            {
                var workoutDay = await _mediator.Send(new GetWorkoutDayIdByDateQuery(DateTime.UtcNow, _userId));
                return Ok(workoutDay);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{workoutDayId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateWorkoutDay(int workoutDayId, [FromBody] WorkoutDayDTO workoutDayDTO)
        {
            try
            {
                var weightConvertResponse = await _weightInsertService.ConvertWorkoutDayWeightsToDbSuitable(_userId, workoutDayDTO);
                var liftingStatsThatPb = await _mediator.Send(new CompleteWorkoutCommand(weightConvertResponse.Data, _userId));
                var convertedPersonalBests = await _weightOutputService.ConvertPersonalBests(liftingStatsThatPb, _userId, weightConvertResponse.IsMetric);
                return Ok(convertedPersonalBests);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutDayNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}