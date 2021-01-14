using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.API.Extensions;
using PowerBuddy.API.Models;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.LiftingStats;
using PowerBuddy.MediatR.LiftingStats.Commands.Account;
using PowerBuddy.MediatR.LiftingStats.Querys.Account;
using PowerBuddy.MediatR.TemplatePrograms.Querys;

namespace PowerBuddy.API.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Account")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _userId;

        public LiftingStatsController(IMediator mediator, IHttpContextAccessor accessor)
        {
            _mediator = mediator;
            _userId = accessor.HttpContext.User.FindUserId();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatAuditDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserLiftingStats()
        {
            var liftingStats = await _mediator.Send(new GetLiftingStatsByUserIdQuery(_userId)).ConfigureAwait(false);
            return Ok(liftingStats);
        }


        [HttpGet("{liftingStatId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatDetailedDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLiftingStatById(int liftingStatId)
        {
            try
            {
                var liftingStatDetailed = await _mediator.Send(new GetLiftingStatByIdQuery(liftingStatId, _userId)).ConfigureAwait(false);
                return Ok(liftingStatDetailed);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Template/{templateProgramId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatAuditDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersonalBestsForTemplate(int templateProgramId)
        {
            var personalBests = await _mediator.Send(new GetPersonalBestsForTemplateExercisesQuery(templateProgramId, _userId)).ConfigureAwait(false);
            return Ok(personalBests);
        }

        [HttpDelete("Audit/{liftingStatAuditId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteLiftingStatAudit(int liftingStatAuditId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteLiftingStatAuditCommand(liftingStatAuditId, _userId)).ConfigureAwait(false);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
