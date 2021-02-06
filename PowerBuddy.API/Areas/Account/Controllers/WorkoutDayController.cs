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
using PowerBuddy.App.Commands.WorkoutDays;
using PowerBuddy.App.Commands.WorkoutDays.Models;
using PowerBuddy.App.Queries.WorkoutDays;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.Workouts;

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
        [ProducesResponseType(typeof(WorkoutDayDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutDayById(int workoutDayId)
        {
            var workoutDayOneOf = await _mediator.Send(new GetWorkoutDayByIdQuery(workoutDayId, _userId));

            if (workoutDayOneOf.IsT0)
            {
                workoutDayOneOf.AsT0.WorkoutExercises = await _weightOutputService.ConvertWorkoutExercises(workoutDayOneOf.AsT0.WorkoutExercises, _userId, null);
            }

            return workoutDayOneOf.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutDayNotFound => NotFound(Errors.Create(nameof(WorkoutDayNotFound))));
        }

        [HttpPost]
        [ProducesResponseType(typeof(WorkoutDayDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWorkoutDay([FromBody] CreateWorkoutDayOptions createWorkoutOptions)
        {

            var result = await _mediator.Send(new CreateWorkoutDayCommand(createWorkoutOptions, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutDayAlreadyExists => BadRequest(Errors.Create(nameof(WorkoutDayAlreadyExists))));
        }

        [HttpGet("Today")]
        [ProducesResponseType(typeof(WorkoutDayDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWorkoutDayIdByDate()
        {
            var workoutDay = await _mediator.Send(new GetWorkoutDayIdByDateQuery(DateTime.UtcNow, _userId));
            return Ok(workoutDay);
        }

        [HttpPut("{workoutDayId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatAuditDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateWorkoutDay(int workoutDayId, [FromBody] WorkoutDayDto workoutDayDto)
        {
            var weightConvertResponse = await _weightInsertService.ConvertWorkoutExerciseWeightsToDbSuitable(_userId, workoutDayDto.WorkoutExercises);
            workoutDayDto.WorkoutExercises = weightConvertResponse.Data;
            var liftingStatsThatPb = await _mediator.Send(new CompleteWorkoutCommand(workoutDayDto, _userId));

            return liftingStatsThatPb.Match<IActionResult>(
                Result => Ok(_weightOutputService.ConvertPersonalBests(Result, _userId, weightConvertResponse.IsMetric).Result),
                WorkoutDayNotFound => NotFound(Errors.Create(nameof(WorkoutDayNotFound))));
        }

        [HttpPut("Note/{workoutExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateWorkoutExerciseNotes(int workoutExerciseId, string notes)
        {

            var result = await _mediator.Send(new UpdateWorkoutDayNotesCommand(workoutExerciseId, notes, _userId));
            return Ok(result);
        }
    }
}