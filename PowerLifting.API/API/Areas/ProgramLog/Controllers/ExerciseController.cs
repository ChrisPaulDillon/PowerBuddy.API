using System;
using System.Collections.Generic;
using System.Linq;
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
            var programLogExercises = await _service.ProgramLogExercise.GetProgramExercisesByProgramLogDayId(programLogDayId);
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
                var exercise = await _service.Exercise.GetExerciseById(programLogExerciseDTO.ExerciseId);
                var programLogExercise = await _service.ProgramLogExercise.CreateProgramLogExercise(_userId, exercise, programLogExerciseDTO);
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
