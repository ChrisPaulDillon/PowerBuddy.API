using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.MediatR.ProgramLogRepSchemes.Commands.Account;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class ProgramLogRepSchemeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProgramLogService _programLogService;
        private readonly string _userId;

        public ProgramLogRepSchemeController(IMediator mediator, IProgramLogService programLogService, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _programLogService = programLogService;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(IEnumerable<ProgramLogRepSchemeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProgramLogRepSchemeCollection([FromBody] IList<ProgramLogRepSchemeDTO> programLogRepSchemeCollection)
        {
            try
            {
                if (!programLogRepSchemeCollection.Any()) return BadRequest();
                var result = await _mediator.Send(new CreateProgramLogRepSchemeCollectionCommand(programLogRepSchemeCollection, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError),StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogRepScheme([FromBody] ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogRepSchemeCommand(programLogRepSchemeDTO, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogRepSchemeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpDelete("{programLogRepSchemeId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProgramLogRepSchemeCommand(programLogRepSchemeId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogRepSchemeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("Count")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTotalRepCount()
        {
            var totalCount = await _programLogService.GetTotalRepSchemeCount();
            return Ok(totalCount);
        }
    }
}
