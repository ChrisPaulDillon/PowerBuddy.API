using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;
using PowerLifting.MediatR.ProgramLogExercises.Command.Member;
using PowerLifting.MediatR.ProgramLogExercises.Query.Account;

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

        public ProgramLogExerciseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{programLogExerciseId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateProgramLogExerciseMember(int programLogExerciseId, [FromBody] ProgramLogExerciseDTO programLogExerciseDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new UpdateProgramLogExerciseMemberCommand(programLogExerciseDTO, userId)).ConfigureAwait(false);
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
    }
}
