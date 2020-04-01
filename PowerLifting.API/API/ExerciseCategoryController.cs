using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseCategoryController : ControllerBase
    {
        private IServiceWrapper _service;

        public ExerciseCategoryController(IServiceWrapper Service)
        {
            _service = Service;
        }

        [HttpGet]
        public IActionResult GetAllExerciseCategories()
        {
            try
            {
                var exerciseCategories =  _service.ExerciseCategory.GetAllCategories();
                if (exerciseCategories == null) return NotFound();
          
                return Ok(exerciseCategories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseCategoryById(int id)
        {
            var category = await _service.ExerciseCategory.GetExerciseCategoryById(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseCategory([FromBody] ExerciseCategoryDTO exerciseCategory)
        {
            if (exerciseCategory == null) return BadRequest("ExerciseCategory object is null");
            if (!ModelState.IsValid) return BadRequest("Invalid ExerciseCategory model object");
            
            var exerciseCategoryCheck = await _service.ExerciseCategory.GetExerciseCategoryByName(exerciseCategory.CategoryName);
            if (exerciseCategoryCheck != null) return Conflict("Exercise Category is already been added");

            //await _service.ExerciseCategory.(exerciseCategory);
              //TODO Fix
            return Ok(exerciseCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseCategory(int id, [FromBody]ExerciseCategoryDTO exerciseCategory)
        {
            if (exerciseCategory == null) return BadRequest("Exercise Category object is null");
            
            if (!ModelState.IsValid) return BadRequest("Invalid model object");

            var exerciseCategoryEntity = await _service.ExerciseCategory.GetExerciseCategoryById(id);
            if (exerciseCategoryEntity == null) return NotFound();
        
            exerciseCategory.ExerciseCategoryId = exerciseCategoryEntity.ExerciseCategoryId;

            //_service.ExerciseCategory.UpdateExerciseCategory(exerciseCategoryEntity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseCategoryAsync(int id)
        {
            var exercise = await _service.ExerciseCategory.GetExerciseCategoryById(id);
            if (exercise == null) return NotFound();
        
            _service.ExerciseCategory.DeleteExerciseCategory(exercise);
            return NoContent();
        }
    }
}
