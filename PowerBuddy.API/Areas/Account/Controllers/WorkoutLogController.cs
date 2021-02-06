﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
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
using PowerBuddy.Data.DTOs.Workouts;

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
        [ProducesResponseType(typeof(IEnumerable<WorkoutStatExtendedDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetWorkoutLogStats()
        {
            try
            {
                var result = await _mediator.Send(new GetAllWorkoutStatsQuery(_userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    WorkoutLogNotFound => NotFound(Errors.Create(nameof(WorkoutLogNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Week")]
        [ProducesResponseType(typeof(WorkoutWeekSummaryDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
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
                var result = await _mediator.Send(new CreateWorkoutLogFromScratchCommand(workoutLog, _userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
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

                var result = await _mediator.Send(new CreateWorkoutLogFromTemplateCommand(workoutLogDTO, templateWorkoutId, _userId));

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    UserNotFound => BadRequest(Errors.Create(nameof(UserNotFound))),
                    TemplateProgramNotFound => NotFound(Errors.Create(nameof(TemplateProgramNotFound))));
            }
            catch (ValidationException ex)
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

                return result.Match<IActionResult>(
                    Result => Ok(Result),
                    WorkoutLogNotFound => NotFound(Errors.Create(nameof(WorkoutLogNotFound))));
            }
            catch (ValidationException ex)
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
