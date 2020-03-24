using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Contracts;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Entities.DTOs.Programs;
using PowerLifting.Entities.Model.Lookups;

namespace PowerLifting.API.API
{
    [Route("api/ExerciseCategory")]
    [ApiController]
    public class ExerciseCategoryController : ControllerBase
    {
        private ILogger<ExerciseCategoryController> _logger;
        private IMapper _mapper;
        private IServiceWrapper _service;
        public ExerciseCategoryController(IServiceWrapper Service, ILogger<ExerciseCategoryController> logger, IMapper mapper)
        {
            _logger = logger;
            _service = Service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExerciseCategories()
        {
            try
            {
                var exerciseCategories = await _service.ExerciseCategory.GetAll();
                if (exerciseCategories == null)
                {
                    _logger.LogError($"No Exercise Categories have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all Exercise Categories");
                    var exerciseCatResult = _mapper.Map<IEnumerable<ExerciseCategoryDTO>>(exerciseCategories);
                    return Ok(exerciseCatResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error returning all Exercise Categories");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseCategoryById(int id)
        {
            try
            {
                var user = await _service.ExerciseCategory.GetExerciseCategoryById(id);

                if (user == null)
                {
                    _logger.LogError($"Exercise Category with name: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Exercise Category with details for id: {id}");

                    var userResult = _mapper.Map<ExerciseCategoryDTO>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetExerciseCategoryByName action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateExerciseCategory([FromBody] ExerciseCategory exerciseCategory)
        {
            try
            {
                if (exerciseCategory == null)
                {
                    _logger.LogError("ExerciseCategory object sent from client is null.");
                    return BadRequest("ExerciseCategory object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid ExerciseCategory object sent from client.");
                    return BadRequest("Invalid ExerciseCategory model object");
                }

                var exerciseCategoryCheck = await _service.ExerciseCategory.GetExerciseCategoryByName(exerciseCategory.CategoryName);
                if (exerciseCategoryCheck != null)
                {
                    _logger.LogError("Exercise Category is already been added");
                    return Conflict("Exercise Category is already been added");
                }

                var exerciseCategoryEntity = _mapper.Map<ExerciseCategory>(exerciseCategory);

                await _service.ExerciseCategory.AddAsync(exerciseCategoryEntity);
                _service.Save();

                var createdUser = _mapper.Map<ExerciseCategoryDTO>(exerciseCategoryEntity);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateExerciseCategory action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseCategoryAsync(int id, [FromBody]ExerciseCategoryDTO exerciseCategory)
        {
            try
            {
                if (exerciseCategory == null)
                {
                    _logger.LogError("Exercise Category object sent from client is null.");
                    return BadRequest("Exercise Category object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Exercise Category object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var exerciseCategoryEntity = await _service.ExerciseCategory.GetExerciseCategoryById(id);
                if (exerciseCategoryEntity == null)
                {
                    _logger.LogError($"Exercise with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                exerciseCategory.ExerciseCategoryId = exerciseCategoryEntity.ExerciseCategoryId;
                _mapper.Map(exerciseCategory, exerciseCategoryEntity);

                _service.ExerciseCategory.UpdateExerciseCategory(exerciseCategoryEntity);
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
        public async Task<IActionResult> DeleteExerciseCategoryAsync(int id)
        {
            try
            {
                var exercise = await _service.ExerciseCategory.GetExerciseCategoryById(id);
                if (exercise == null)
                {
                    _logger.LogError($"Exercise Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _service.ExerciseCategory.DeleteExerciseCategory(exercise);
                _service.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteExerciseCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
