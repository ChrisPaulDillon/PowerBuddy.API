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
using PowerBuddy.MediatR.ProgramLogs.Commands;
using PowerBuddy.MediatR.ProgramLogs.Querys;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize]
    public class ProgramLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet("Stat")]
        [ProducesResponseType(typeof(IEnumerable<ProgramLogStatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogStats()
        {
            try
            {
                var ProgramLogStats = await _mediator.Send(new GetAllProgramLogStatsQuery(_userId));
                return Ok(ProgramLogStats);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("Scratch")]
        [ProducesResponseType(typeof(ProgramLogDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateProgramLogFromScratch([FromBody] ProgramLogInputScratchDTO ProgramLog)
        {
            try
            {
                var createdLog = await _mediator.Send(new CreateProgramLogFromScratchCommand(ProgramLog, _userId));
                return Ok(createdLog);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ProgramLogAlreadyActiveException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
