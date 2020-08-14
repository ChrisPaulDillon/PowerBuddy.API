using System.Collections.Generic;
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
    public class ProgramLogRepSchemeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramLogRepSchemeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public IActionResult CreateProgramLogRepSchemeCollection([FromBody] IEnumerable<ProgramLogRepSchemeDTO> programLogRepSchemeCollection)
        {
            try
            {
                var result = _service.ProgramLogRepScheme.CreateProgramLogExerciseCollection(programLogRepSchemeCollection);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogRepSchemeNotFoundException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                await _service.ProgramLogRepScheme.UpdateProgramLogRepScheme(programLogRepSchemeDTO);
                return NoContent();
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

        [HttpDelete("{programLogRepSchemeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLogRepSchemeAsync(int programLogRepSchemeId)
        {
            try
            {
                var result = await _service.ProgramLogRepScheme.DeleteProgramLogRepScheme(programLogRepSchemeId);
                return Ok(result);
            }
            catch (ProgramLogDayNotWithinWeekException e)
            {
                return Unauthorized(e);
            }
        }
    }
}
