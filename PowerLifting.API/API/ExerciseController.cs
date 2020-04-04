using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.Exercises.Exceptions;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllExercises()
        {       
            var exercises = _service.Exercise.GetAllExercises();
            if (exercises == null) return NotFound();
            return Ok(exercises);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            try
            {
                var exercise = await _service.Exercise.GetExerciseById(id);
                return Ok(exercise);
            }
            catch (ExerciseNotFoundException e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("ExerciseType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllExerciseTypes()
        {
            var exerciseTypes = _service.ExerciseType.GetAllExerciseTypes();
            if (exerciseTypes == null) return NotFound();
            return Ok(exerciseTypes);
        }

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllExerciseMuscleGroups()
        {
            var exerciseMuscleGroups = _service.ExerciseMuscleGroup.GetAllExerciseMuscleGroups();
            if (exerciseMuscleGroups == null) return NotFound();
            return Ok(exerciseMuscleGroups);
        }
    }
}
