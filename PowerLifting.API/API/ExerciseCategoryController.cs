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
       
        private IServiceWrapper _service;
        public ExerciseCategoryController(IServiceWrapper Service, ILogger<ExerciseCategoryController> logger)
        {
            _logger = logger;
            _service = Service;
       
        }

        [HttpGet]
        public IActionResult GetAllExerciseCategories()
        {
            try
            {
                var exerciseCategories =  _service.ExerciseCategory.GetAllCategories();
                if (exerciseCategories == null)
                {
                    _logger.LogError($"No Exercise Categories have been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned all Exercise Categories");
               
                    return Ok(exerciseCategories);
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
            var category = await _service.ExerciseCategory.GetExerciseCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateExerciseCategory([FromBody] ExerciseCategoryDTO exerciseCategory)
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


            //await _service.ExerciseCategory.AddAsync(exerciseCategory);
            _service.Save();
              //TODO Fix
            return Ok(exerciseCategory);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseCategoryAsync(int id, [FromBody]ExerciseCategoryDTO exerciseCategory)
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

            //_service.ExerciseCategory.UpdateExerciseCategory(exerciseCategoryEntity);
            _service.Save();

            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseCategoryAsync(int id)
        {

            var exercise = await _service.ExerciseCategory.GetExerciseCategoryById(id);
            if (exercise == null)
            {
                _logger.LogError($"Exercise Category with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            //_service.ExerciseCategory.DeleteExerciseCategory(exercise);
            _service.Save();
            //TODO fix
            return NoContent();

        }
    }
}
