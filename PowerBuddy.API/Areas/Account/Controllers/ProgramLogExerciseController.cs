using System.Collections.Generic;
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
using PowerBuddy.MediatR.ProgramLogExercises.Commands.Account;
using PowerBuddy.MediatR.ProgramLogExercises.Querys.Account;

namespace PowerBuddy.API.Areas.Account.Controllers
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
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ReachedMaxSetsOnExerciseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return BadRequest(ex.Message);
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
                return NotFound(ex.Message);
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
                return NotFound(ex.Message);
            }
        }
    }
}
