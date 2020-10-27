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
using PowerLifting.MediatR.ProgramLogExercises.Command.Member;

namespace PowerLifting.API.Areas.Member.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Member")]
    public class ProgramLogExerciseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogExerciseController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPut("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExerciseMember(int programLogExerciseId, [FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                var liftingStatsThatPb = await _mediator.Send(new UpdateProgramLogExerciseMemberCommand(programLogExerciseDTO, _userId)).ConfigureAwait(false);
                return Ok(liftingStatsThatPb);
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
    }
}
