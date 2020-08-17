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
using PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account;

namespace PowerLifting.API.Areas.Account.Controllers
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
        public async Task<IActionResult> CreateProgramLogRepSchemeCollectionAsync([FromBody] IList<ProgramLogRepSchemeDTO> programLogRepSchemeCollection)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new CreateProgramLogRepSchemeCollectionCommand(programLogRepSchemeCollection, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogRepSchemeNotFoundException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new UpdateProgramLogRepSchemeCommand(programLogRepSchemeDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
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
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new DeleteProgramLogRepSchemeCommand(programLogRepSchemeId, userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ProgramLogDayNotWithinWeekException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
