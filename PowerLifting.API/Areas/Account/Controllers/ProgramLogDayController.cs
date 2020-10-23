using System;
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
using PowerLifting.MediatR.ProgramLogDays.Command.Account;
using PowerLifting.MediatR.ProgramLogDays.Command.Member;
using PowerLifting.MediatR.ProgramLogDays.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Area("Account")]
    public class ProgramLogDayController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogDayController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }
        [HttpGet]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByDate(DateTime dateSelected)
        {
            try
            {
                var programLogDay = await _mediator.Send(new GetProgramLogDayByDateQuery(dateSelected, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("LogSpecific/{programLogId:int}")]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayByProgramLogId(int programLogId, DateTime dateSelected)
        {
            try
            {
                var programLogDay = await _mediator.Send(new GetProgramSpecificDayByDateQuery(dateSelected, programLogId, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogDay));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpGet("{programLogDayId:int}", Name = nameof(GetProgramLogDayById))]
        [ProducesResponseType(typeof(ProgramLogDayDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogDayById(int programLogDayId)
        {
            try
            {
                var programLogDayDTO = await _mediator.Send(new GetProgramLogDayByIdQuery(programLogDayId, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogDayDTO));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut("{programLogDayId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProgramLogDay(int programLogDayId, [FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            try
            {
                //var result = await _mediator.Send(new UpdateProgramLogDayCommand(programLogDayDTO, _userId)).ConfigureAwait(false);
                //return Ok(Responses.Success(result));

                var liftingStatsThatPb = await _mediator.Send(new UpdateProgramLogDayMemberCommand(programLogDayDTO, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(liftingStatsThatPb));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateProgramLogDay([FromBody] ProgramLogDayDTO programLogDayDTO)
        {
            try
            {
                var createdProgramLogDayDTO = await _mediator.Send(new CreateProgramLogDayCommand(programLogDayDTO, _userId)).ConfigureAwait(false);
                return CreatedAtRoute(nameof(GetProgramLogDayById), new {programLogDayId = createdProgramLogDayDTO.ProgramLogDayId}, createdProgramLogDayDTO);
            }
            catch (ProgramLogDayNotWithinWeekException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (ProgramLogWeekNotFoundException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (ProgramLogDayOnDateAlreadyActiveException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpDelete("{programLogDayId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteProgramLogDay(int programLogDayId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProgramLogDayCommand(programLogDayId, _userId))
                    .ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpPut("Note/{programLogDayId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProgramLogDayNotes(int programLogDayId, string notes)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProgramLogDayNotesCommand(programLogDayId, notes, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (ProgramLogDayNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
