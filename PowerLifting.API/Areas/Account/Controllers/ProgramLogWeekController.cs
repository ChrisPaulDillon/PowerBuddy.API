﻿using System;
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
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.MediatR.ProgramLogs.Query.Account;
using PowerLifting.MediatR.ProgramLogWeeks.Command.Account;
using PowerLifting.MediatR.ProgramLogWeeks.Query.Account;
using PowerLifting.MediatR.TemplatePrograms.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProgramLogWeekController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public ProgramLogWeekController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpPost("{programLogId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWeekDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateProgramLogWeek(int programLogId)
        {
            try
            {
                var programLogWeek = await _mediator.Send(new AddProgramLogWeekToLogCommand(programLogId, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogWeek));
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpGet("Week/{date}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWeekDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProgramLogWeekByDate(DateTime date)
        {
            try
            { 
                var programLogWeek = await _mediator.Send(new GetProgramLogWeekBetweenDateQuery(date, _userId)).ConfigureAwait(false);
                return Ok(Responses.Success(programLogWeek));
            }
            catch (ProgramLogWeekNotFoundException ex)
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