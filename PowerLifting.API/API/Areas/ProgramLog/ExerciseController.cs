using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Common.Exceptions;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.ProgramLogs.Exceptions;

namespace PowerLifting.API.API.Areas.ProgramLog
{
    [Route("api/ProgramLog/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProgramLogExerciseController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public ProgramLogExerciseController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("Exercise/{programLogDayId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogExerciseDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDayExercises(int programLogDayId)
        {
            var programLogExercises = await _service.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId);
            return Ok(Responses.Success(programLogExercises));
        }

        [HttpPost("Exercise/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogExercise(string userId, [FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                _service.ProgramLogExercise.CreateProgramLogExercise(userId, programLogExerciseDTO);
                return Ok(Responses.Success());
            }
            catch (ProgramLogDayNotWithWeekRangeException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpPut("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExercise([FromBody] ProgramLogExerciseDTO programLogDTO)
        {
            try
            {
                await _service.ProgramLogExercise.UpdateProgramLogExercise(programLogDTO);
                return Ok(Responses.Success());
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

        [HttpDelete("Exercise")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public IActionResult DeleteProgramLogExercise(int programLogExerciseId)
        {
            try
            {
                _service.ProgramLogExercise.DeleteProgramLogExercise(programLogExerciseId);
                return Ok(Responses.Success());
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
