using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Contracts;
using PowerLifting.Cypto;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;

namespace PowerLifting.API.API
{
    [Route("api/Exercises")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private ILogger<ExerciseController> _logger;
        private IMapper _mapper;
        private IServiceWrapper _service;
        public ExerciseController(IServiceWrapper service, ILogger<ExerciseController> logger, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            try
            {
                var exercises = await _service.Exercise.GetAllIncludeCategories();
                if (exercises == null)
                {
                    _logger.LogError($"No Exercises have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all Exercises");
                    var exerciseResult = _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
                    return Ok(exerciseResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error returning all Exercises");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Name/{name}")]
        public async Task<IActionResult> GetExercise(string exerciseName)
        {
            try
            {
                var Exercise = await _service.Exercise.GetExerciseByName(exerciseName);

                if (Exercise == null)
                {
                    _logger.LogError($"Exercise with name: {exerciseName}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Exercise with details for id: {exerciseName}");

                    var ExerciseResult = _mapper.Map<ExerciseDTO>(Exercise);
                    return Ok(ExerciseResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetExercise action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] Exercise exercise)
        {
            try
            {
                if (exercise == null)
                {
                    _logger.LogError("Exercise object sent from client is null.");
                    return BadRequest("Exercise object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Exercise object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var exerciseCheck = await _service.Exercise.GetExerciseByName(exercise.ExerciseName);
                if (exerciseCheck != null)
                {
                    _logger.LogError("Exercise is already been added");
                    return Conflict("Exercise is already been added");
                }

                var exerciseEntity = _mapper.Map<Exercise>(exercise);

                await _service.Exercise.AddAsync(exerciseEntity);
                _service.Save();

                var createdExercise = _mapper.Map<ExerciseDTO>(exerciseEntity);
                return Ok(createdExercise);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateExercise action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseAsync(int id, [FromBody]ExerciseDTO Exercise)
        {
            try
            {
                if (Exercise == null)
                {
                    _logger.LogError("Exercise object sent from client is null.");
                    return BadRequest("Exercise object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Exercise object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ExerciseEntity = await _service.Exercise.GetExerciseById(id);
                if (ExerciseEntity == null)
                {
                    _logger.LogError($"Exercise with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(Exercise, ExerciseEntity);

                _service.Exercise.Update(ExerciseEntity);
                _service.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateExercise action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseAsync(int id)
        {
            try
            {
                var Exercise = await _service.Exercise.GetExerciseById(id);
                if (Exercise == null)
                {
                    _logger.LogError($"Exercise with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _service.Exercise.DeleteExercise(Exercise);
                _service.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteExercise action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
