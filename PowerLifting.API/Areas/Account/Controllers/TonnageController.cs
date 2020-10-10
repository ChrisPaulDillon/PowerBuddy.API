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
using PowerLifting.MediatR.ProgramLogWeeks.Command.Account;
using PowerLifting.MediatR.ProgramLogWeeks.Query.Account;
using PowerLifting.Service.Tonnages;

namespace PowerLifting.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class TonnageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;
        private readonly ITonnageService _tonnageService;

        public TonnageController(IMediator mediator, IHttpContextAccessor accessor, ITonnageService tonnageService)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
            _tonnageService = tonnageService;
        }

        [HttpPost("{programLogId:int}")]
        [ProducesResponseType(typeof(ApiResponse<ProgramLogWeekDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateTonnageForLog(int programLogId, int programLogDayId)
        {
            try
            {
                var userId = "533b69ac-499c-4d4d-ac01-ab41643b9cde";
                var tonnage = await _tonnageService.CreateTonnageBreakdownForDay(programLogId, programLogDayId, userId);
                return Ok(Responses.Success(tonnage));
            }
            catch (ProgramLogNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}

