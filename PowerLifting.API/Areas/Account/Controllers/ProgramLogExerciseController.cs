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
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;
using PowerLifting.MediatR.ProgramLogExercises.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class ProgramLogExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogExerciseController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("{programLogExerciseId:int}", Name = "ProgramLogExerciseById")]
        [ProducesResponseType(typeof(IEnumerable<ProgramLogExerciseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramLogDayExerciseById(int programLogExerciseId)
        {
            var programLogExercise = await _mediator.Send(new GetProgramLogExerciseByIdQuery(programLogExerciseId)).ConfigureAwait(false);
            return Ok(programLogExercise);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogExercise([FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                var programLogExercise = await _mediator.Send(new CreateProgramLogExerciseCommand(programLogExerciseDTO, _userId)).ConfigureAwait(false);
                return CreatedAtRoute("ProgramLogExerciseById", new { programLogExerciseId = programLogExercise.ProgramLogExerciseId }, programLogExercise);
            }
            catch (ReachedMaxSetsOnExerciseException ex)
            {
                return BadRequest(ex);
            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExercise(int programLogExerciseId, [FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogExerciseCommand(programLogExerciseDTO, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex);
            }
        }

        [HttpDelete("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLogExercise(int programLogExerciseId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProgramLogExerciseCommand(programLogExerciseId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (UnauthorisedUserException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("Note/{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExerciseNotes(int programLogExerciseId, string notes)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogExerciseNotesCommand(programLogExerciseId, notes, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ProgramLogExerciseNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (UnauthorisedUserException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
