using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Extensions;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class ProgramLogRepSchemeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogRepSchemeController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ProgramLogRepSchemeDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogRepSchemeCollection([FromBody] IList<ProgramLogRepSchemeDTO> programLogRepSchemeCollection)
        {
            try
            {
                var result = await _mediator.Send(new CreateProgramLogRepSchemeCollectionCommand(programLogRepSchemeCollection, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
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

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogRepSchemeCommand(programLogRepSchemeDTO, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogRepSchemeNotFoundException e)
            {
                return NotFound(e);
            }
            catch (ProgramLogExerciseNotFoundException e)
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
                var result = await _mediator.Send(new DeleteProgramLogRepSchemeCommand(programLogRepSchemeId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ProgramLogDayNotWithinWeekException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
