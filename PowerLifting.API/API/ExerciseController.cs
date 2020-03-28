using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private ILogger<ExerciseController> _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _wrapper;
        private IServiceWrapper _service;

        public ExerciseController(IRepositoryWrapper wrapper, IServiceWrapper service, ILogger<ExerciseController> logger, IMapper mapper)
        {
            _logger = logger;
            _wrapper = wrapper;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAllExercises()
        {
            var exercises = _service.Exercise.GetAllExercises();
            if (exercises == null)
            {
                return NotFound();
            }
            return Ok(exercises);
        }

        [HttpGet("Name/{name}")]
        public async Task<IActionResult> GetExercise(string exerciseName)
        {
            var exercise = await _service.Exercise.GetExerciseByName(exerciseName);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseDTO exercise)
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

            //await _service.Exercise.AddAsync(exerciseEntity);
            //_service.Save();

            return Ok(exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseAsync(int id, [FromBody]ExerciseDTO exercise)
        {

            if (exercise == null)
            {
                return BadRequest("Exercise object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var ExerciseEntity = await _service.Exercise.GetExerciseById(id);
            if (ExerciseEntity == null)
            {
                _logger.LogError($"Exercise with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _mapper.Map(exercise, ExerciseEntity);

            //_service.Exercise.Update(exercise);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseAsync(int id)
        {
            var exercise = await _service.Exercise.GetExerciseById(id);
            if (exercise == null)
            {
                return NotFound();
            }

            //_service.Exercise.DeleteExercise(Exercise);

            return NoContent();
        }
    }
}
