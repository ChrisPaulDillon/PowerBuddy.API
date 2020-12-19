using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.MediatR.Workouts.Commands;
using PowerBuddy.MediatR.Workouts.Querys;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class WorkoutLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public WorkoutLogController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            if (accessor.HttpContext != null) _userId = accessor.HttpContext.User.FindUserId();
        }

        //[HttpGet("Stat")]
        //[ProducesResponseType(typeof(IEnumerable<WorkoutLogStatDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> GetWorkoutLogStats()
        //{
        //    try
        //    {
        //        var WorkoutLogStats = await _mediator.Send(new GetAllWorkoutLogStatsQuery(_userId)).ConfigureAwait(false);
        //        return Ok(WorkoutLogStats);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (WorkoutLogNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (UnauthorisedUserException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //}

        [HttpGet("Week")]
        [ProducesResponseType(typeof(WorkoutLogDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWorkoutWeekByDate()
        {
            try
            {
                var WorkoutLog = await _mediator.Send(new GetWorkoutWeekByDateQuery(DateTime.UtcNow, _userId)).ConfigureAwait(false);
                return Ok(WorkoutLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        //[HttpGet("{WorkoutLogId:int}")]
        //[ProducesResponseType(typeof(WorkoutLogDTO), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> GetWorkoutLogById(int WorkoutLogId)
        //{
        //    try
        //    {
        //        var WorkoutLog = await _mediator.Send(new GetWorkoutLogByIdQuery(WorkoutLogId, _userId)).ConfigureAwait(false);
        //        return Ok(WorkoutLog);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (UserProfileNotPublicException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (WorkoutLogNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (UnauthorisedUserException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //}

        //[HttpPost("Scratch")]
        //[ProducesResponseType(typeof(WorkoutLogDTO), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> CreateWorkoutLogFromScratch([FromBody] WorkoutLogInputScratchDTO WorkoutLog)
        //{
        //    try
        //    {
        //        var createdLog = await _mediator.Send(new CreateWorkoutLogFromScratchCommand(WorkoutLog, _userId)).ConfigureAwait(false);
        //        return Ok(createdLog);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (UnauthorisedUserException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //    catch (WorkoutLogAlreadyActiveException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost("Template/{templateWorkoutId:int}")]
        [ProducesResponseType(typeof(WorkoutLogDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWorkoutLogFromTemplate(int templateWorkoutId, [FromBody] WorkoutLogTemplateInputDTO workoutLogDTO)
        {
            try
            {
                var isCreated = await _mediator.Send(new CreateWorkoutLogFromTemplateCommand(workoutLogDTO, templateWorkoutId, _userId)).ConfigureAwait(false);
                return Ok(isCreated);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (TemplateProgramNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (TemplateExercise1RMNotSetForUserException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{WorkoutLogId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteWorkoutLog(int workoutLogId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteWorkoutLogCommand(workoutLogId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("Calendar")]
        //[ProducesResponseType(typeof(IEnumerable<DateTime>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetWorkoutLogCalendarStats()
        //{
        //    try
        //    {
        //        var dates = await _mediator.Send(new GetAllWorkoutLogCalendarStatsQuery(_userId)).ConfigureAwait(false);
        //        return Ok(dates);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (WorkoutLogDayNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (UnauthorisedUserException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //}
    }
}
