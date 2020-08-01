using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.API.Areas.ProgramLog.Controllers
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private string _userId = "";

        public ExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("{programLogDayId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogExerciseDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDayExercisesByDay(int programLogDayId)
        {
            var programLogExercises = await _service.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId, _userId);
            return Ok(Responses.Success(programLogExercises));
        }

        [HttpGet("{programLogExerciseId:int}", Name = "ProgramLogExerciseById")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogExerciseDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDayExerciseById(int programLogExerciseId)
        {
            var programLogExercise = await _service.ProgramLogExercise.GetProgramLogExerciseById(programLogExerciseId);
            return Ok(Responses.Success(programLogExercise));
        }


        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogExercise([FromBody] CProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var programLogExercise = await _service.ProgramLogExercise.CreateProgramLogExercise(programLogExerciseDTO, _userId);
                return CreatedAtRoute("ProgramLogExerciseById", new { programLogExerciseId = programLogExercise.ProgramLogExerciseId }, programLogExercise);

            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpPut("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExercise(int programlogExerciseId, [FromBody] ProgramLogExerciseDTO programLogDTO)
        {
            try
            {
                var didUpdate = await _service.ProgramLogExercise.UpdateProgramLogExercise(programLogDTO, _userId);
                return Ok(Responses.Success(didUpdate));
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut("Mark/{programLogExerciseId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> MarkProgramLogExerciseComplete(int programLogExerciseId, bool isCompleted)
        {
            try
            {
                var result = await _service.ProgramLogExercise.MarkProgramLogExerciseComplete(programLogExerciseId, isCompleted);
                return Ok(Responses.Success());
            }
            catch (ProgramLogNotFoundException e)
            {
                return NotFound(e);
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpDelete("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProgramLogExerciseAsync(int programLogExerciseId)
        {
            try
            {
                var isDeleted = await _service.ProgramLogExercise.DeleteProgramLogExercise(programLogExerciseId, _userId);
                return Ok(Responses.Success(isDeleted));
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
