using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Powerlifting.Service.Exercises.DTO;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private IServiceWrapper _service;

        public ExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllExercises()
        {
            var exercises = _service.Exercise.GetAllExercises();
            if (exercises == null) return NotFound();
            
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseDTO exercise)
        {
            if (exercise == null) return BadRequest("Exercise object is null");

            if (!ModelState.IsValid) return BadRequest("Invalid model object");

            var exerciseCheck = await _service.Exercise.GetExerciseById(exercise.ExerciseId);
            if (exerciseCheck != null) return Conflict("Exercise is already been added");
          
            //var exerciseEntity = _mapper.Map<Exercise>(exercise);

            //await _service.Exercise.AddAsync(exerciseEntity);
            //_service.Save();
            return Ok(exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody]ExerciseDTO exercise)
        {
            if (exercise == null) return BadRequest("Exercise object is null");

            if (!ModelState.IsValid) return BadRequest("Invalid model object");

            var ExerciseEntity = await _service.Exercise.GetExerciseById(id);
            if (ExerciseEntity == null) return NotFound();
           
            //_mapper.Map(exercise, ExerciseEntity);

            //_service.Exercise.Update(exercise);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseAsync(int id)
        {
            var exercise = await _service.Exercise.GetExerciseById(id);
            if (exercise == null) return NotFound();
           
            _service.Exercise.DeleteExercise(exercise);
            return NoContent();
        }
    }
}
