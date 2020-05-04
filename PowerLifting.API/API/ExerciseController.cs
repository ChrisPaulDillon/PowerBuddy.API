using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Exceptions;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public ExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TopLevelExerciseDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllExercises()
        {       
            var exercises = _service.Exercise.GetAllExercises();
            if (exercises == null) return NotFound();
            return Ok(exercises);
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExerciseDTO),StatusCodes.Status200OK)]
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

        [HttpGet("ExerciseMuscleGroup")]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllExerciseMuscleGroups()
        {
            try
            {
                var exercises = _service.ExerciseMuscleGroup.GetAllExerciseMuscleGroups();
                return Ok(exercises);
            }
            catch (ExerciseNotFoundException e)
            {
                return NotFound(e);
            }    
        }

        [HttpGet("ExerciseType")]
        [ProducesResponseType(typeof(IEnumerable<ExerciseTypeDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllExerciseTypes()
        {
            var exerciseTypes = _service.ExerciseType.GetAllExerciseTypes();
            if (exerciseTypes == null) return NotFound();
            return Ok(exerciseTypes);
        }
    }
}
