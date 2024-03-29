﻿using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.App.Commands.WorkoutExercises;
using PowerBuddy.App.Services.Weights;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Area("Account")]
    public class WorkoutExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWeightInsertConvertorService _weightInsertService;
        private readonly IWeightOutgoingConvertorService _weightOutputService;
        private readonly string _userId;

        public WorkoutExerciseController(IMediator mediator, IWeightInsertConvertorService weightInsertService, IWeightOutgoingConvertorService weightOutgoingService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _weightInsertService = weightInsertService;
            _weightOutputService = weightOutgoingService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateWorkoutExercise([FromBody] CreateWorkoutExerciseDto createWorkoutExerciseDto)
        {
            var convertedWorkoutWeight = await _weightInsertService.ConvertGenericWeightToDbSuitable(_userId, createWorkoutExerciseDto.Weight);
            createWorkoutExerciseDto.Weight = convertedWorkoutWeight.Data;

            var result = await _mediator.Send(new CreateWorkoutExerciseCommand(createWorkoutExerciseDto, _userId));

            if (result.IsT0)
            {
                result.AsT0.WorkoutSets = await _weightOutputService.ConvertWorkoutSets(result.AsT0.WorkoutSets, _userId, convertedWorkoutWeight.IsMetric);
            }

            return result.Match<IActionResult>(
                Result => Ok(Result),
                WorkoutDayNotFound => NotFound(Errors.Create(nameof(WorkoutDayNotFound))),
                ExerciseNotFound => NotFound(Errors.Create(nameof(ExerciseNotFound))),
                ReachedMaxSetsOnExercise => BadRequest((Errors.Create(nameof(ReachedMaxSetsOnExercise)))));
        }

        [HttpDelete("{workoutExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteWorkoutExercise(int workoutExerciseId)
        {
            var result = await _mediator.Send(new DeleteWorkoutExerciseCommand(workoutExerciseId, _userId));
            return Ok(result);
        }

        [HttpPut("Note/{workoutExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateWorkoutExerciseNotes(int workoutExerciseId, string notes)
        {

            var result = await _mediator.Send(new UpdateWorkoutExerciseNotesCommand(workoutExerciseId, notes, _userId));
            return Ok(result);
        }
    }
}
