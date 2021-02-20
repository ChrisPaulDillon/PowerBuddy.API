using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.Workouts;
using PowerBuddy.App.Queries.Workouts;
using PowerBuddy.App.Queries.Workouts.Models;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize]
    public class WorkoutLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightInsertConvertorService _weightInsertService;
        private readonly string _userId;

        public WorkoutLogController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Stat")]
        [ProducesResponseType(typeof(IEnumerable<WorkoutStatExtendedDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutLogStats()
        {
            var result = await _mediator.Send(new GetAllWorkoutStatsQuery(_userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutLogNotFound => NotFound(Errors.Create(nameof(WorkoutLogNotFound))));
        }

        [HttpGet("Week")]
        [ProducesResponseType(typeof(WorkoutWeekSummaryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutWeekByDate(DateTime? date)
        {
            var workoutWeek = await _mediator.Send(new GetWorkoutWeekByDateQuery(date ?? DateTime.UtcNow, _userId));
            return Ok(workoutWeek);
        }

        [HttpGet("{WorkoutLogId:int}")]
        [ProducesResponseType(typeof(WorkoutLogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWorkoutLogById(int workoutLogId)
        {
            var result = await _mediator.Send(new GetWorkoutLogByIdQuery(workoutLogId, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutLogNotFound => NotFound(Errors.Create(nameof(WorkoutLogNotFound))));
        }

        [HttpPost("Scratch")]
        [ProducesResponseType(typeof(WorkoutLogDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateWorkoutLogFromScratch([FromBody] WorkoutLogInputScratchDto workoutLog)
        {
            var result = await _mediator.Send(new CreateWorkoutLogFromScratchCommand(workoutLog, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
        }

        [HttpPost("Template/{templateWorkoutId:int}")]
        [ProducesResponseType(typeof(WorkoutLogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWorkoutLogFromTemplate(int templateWorkoutId,
            [FromBody] WorkoutLogTemplateInputDto workoutLogDto)
        {
            if (workoutLogDto.IncrementalWeightInputs != null)
            {
                workoutLogDto.IncrementalWeightInputs = await _weightInsertService.ConvertWeightInputsToDbSuitable(_userId, workoutLogDto.IncrementalWeightInputs);
            }

            if (workoutLogDto.WeightInputs != null)
            {
                workoutLogDto.WeightInputs = await _weightInsertService.ConvertWeightInputsToDbSuitable(_userId, workoutLogDto.WeightInputs);
            }

            var result = await _mediator.Send(new CreateWorkoutLogFromTemplateCommand(workoutLogDto, templateWorkoutId, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutLogExistsOnDate => BadRequest(Errors.Create(nameof(WorkoutLogExistsOnDate), WorkoutLogExistsOnDate.Message)),
                UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))),
                TemplateProgramNotFound => NotFound(Errors.Create(nameof(TemplateProgramNotFound))));
        }

        [HttpDelete("{WorkoutLogId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteWorkoutLog(int workoutLogId)
        {
            var result = await _mediator.Send(new DeleteWorkoutLogCommand(workoutLogId, _userId));

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutLogNotFound => NotFound(Errors.Create(nameof(WorkoutLogNotFound))));
        }

        [HttpGet("Calendar")]
        [ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutCalendar()
        {
            var dates = await _mediator.Send(new GetWorkoutCalendarQuery(_userId));
            return Ok(dates);
        }
    }
}
