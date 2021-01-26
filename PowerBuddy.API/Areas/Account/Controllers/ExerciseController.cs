﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Data.Exceptions.Exercises;
using PowerBuddy.MediatR.Exercises.Commands.Account;
using PowerBuddy.MediatR.Exercises.Querys.Public;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [Area("Account")]
    public class ExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ExerciseController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<TopLevelExerciseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateExercise([FromBody] CExerciseDTO exerciseDTO)
        {
            try
            {
                var exercise = await _mediator.Send(new CreateExerciseCommand(exerciseDTO));
                return CreatedAtRoute(nameof(GetExerciseById), new { exerciseId = exercise.ExerciseId }, exercise);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExerciseAlreadyExistsException e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{exerciseId:int}", Name = nameof(GetExerciseById))]
        [ProducesResponseType(typeof(TopLevelExerciseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            try
            {
                var exercises = await _mediator.Send(new GetExerciseByIdQuery(exerciseId));
                return Ok(exercises);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExerciseNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
