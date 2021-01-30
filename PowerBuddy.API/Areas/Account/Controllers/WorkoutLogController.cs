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
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.MediatR.Workouts.Commands;
using PowerBuddy.MediatR.Workouts.Models;
using PowerBuddy.MediatR.Workouts.Querys;
using PowerBuddy.Services.Weights;

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
        private readonly IWeightOutgoingConvertorService _weightOutputService;
        private readonly string _userId;

        public WorkoutLogController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IWeightOutgoingConvertorService weightOutputService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _weightOutputService = weightOutputService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Stat")]
        [ProducesResponseType(typeof(IEnumerable<WorkoutStatExtendedDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWorkoutLogStats()
        {
            try
            {
                var workoutLogStats = await _mediator.Send(new GetAllWorkoutStatsQuery(_userId));
                return Ok(workoutLogStats);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (WorkoutLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Week")]
        [ProducesResponseType(typeof(WorkoutWeekSummaryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetWorkoutWeekByDate(DateTime? date)
        {
            try
            {
                var workoutWeek = await _mediator.Send(new GetWorkoutWeekByDateQuery(date?? DateTime.UtcNow, _userId));
                return Ok(workoutWeek);
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

        //[HttpGet("{WorkoutLogId:int}")]
        //[ProducesResponseType(typeof(WorkoutLogDTO), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        //public async Task<IActionResult> GetWorkoutLogById(int WorkoutLogId)
        //{
        //    try
        //    {
        //        var WorkoutLog = await _mediator.Send(new GetWorkoutLogByIdQuery(WorkoutLogId, _userId));
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
        //    catch (UserNotFoundException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //}

        [HttpPost("Scratch")]
        [ProducesResponseType(typeof(WorkoutLogDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateWorkoutLogFromScratch([FromBody] WorkoutLogInputScratchDTO workoutLog)
        {
            try
            {
                var createdLog = await _mediator.Send(new CreateWorkoutLogFromScratchCommand(workoutLog, _userId));
                return Ok(createdLog);
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
                if (workoutLogDTO.IncrementalWeightInputs != null)
                {
                    workoutLogDTO.IncrementalWeightInputs = await _weightInsertService.ConvertWeightInputsToDbSuitable(_userId, workoutLogDTO.IncrementalWeightInputs);
                }
                if (workoutLogDTO.WeightInputs != null)
                {
                    workoutLogDTO.WeightInputs = await _weightInsertService.ConvertWeightInputsToDbSuitable(_userId, workoutLogDTO.WeightInputs);
                }
                var isCreated = await _mediator.Send(new CreateWorkoutLogFromTemplateCommand(workoutLogDTO, templateWorkoutId, _userId));
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
            catch (WorkoutDaysDoesNotMatchTemplateDaysException ex)
            {
                return BadRequest(ex.Message);
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
                var result = await _mediator.Send(new DeleteWorkoutLogCommand(workoutLogId, _userId));
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
            catch (UserNotFoundException ex)
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
        //        var dates = await _mediator.Send(new GetAllWorkoutLogCalendarStatsQuery(_userId));
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
        //    catch (UserNotFoundException ex)
        //    {
        //        return Unauthorized(ex.Message);
        //    }
        //}
    }
}
