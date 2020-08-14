using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.API.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    public class ProgramLogExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private string _userId = "";

        public ProgramLogExerciseController(IMediator mediator)
        {
            _mediator = mediator;
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

        [HttpDelete("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProgramLogExercise(int programLogExerciseId)
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
