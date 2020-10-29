using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Extensions;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.MediatR.LiftingStats.Query.Account;
using PowerLifting.MediatR.TemplatePrograms.Query.Account;

namespace PowerLifting.API.Areas.Account.Controllers
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
        [ProducesResponseType(typeof(IEnumerable<LiftingStatDTO>), StatusCodes.Status200OK)]
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
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Template/{templateProgramId:int}")]
        [ProducesResponseType(typeof(IEnumerable<LiftingStatDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersonalBestsForTemplate(int templateProgramId)
        {
            var personalBests = await _mediator.Send(new GetPersonalBestsForTemplateExercisesQuery(templateProgramId, _userId)).ConfigureAwait(false);
            return Ok(personalBests);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateLiftingStat([FromBody] LiftingStatDTO liftingStatDTO)
        {
            try
            {
                var liftingStat = await _mediator.Send(new CreateLiftingStatCommand(liftingStatDTO, _userId)).ConfigureAwait(false);
                return Ok(liftingStat);
            }
            catch (LiftingStatAlreadyExistsException e)
            {
                return BadRequest(e);
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(e);
            }
        }

        [HttpPost("Collection")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateLiftingStatCollection([FromBody] IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
            try
            {
                var liftingStat = await _mediator.Send(new CreateLiftingStatCollectionCommand(liftingStatCollectionDTO, _userId)).ConfigureAwait(false);
                return Ok(liftingStat);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("Collection")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLiftingStatCollection([FromBody] IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
            try
            {
                var liftingStat = await _mediator.Send(new UpdateLiftingStatCollectionCommand(liftingStatCollectionDTO, _userId)).ConfigureAwait(false);
                return Ok(liftingStat);
            }
            catch (LiftingStatAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLiftingStat([FromBody] LiftingStatDTO liftingStats)
        {
            try
            {
                var result = await _mediator.Send(new UpdateLiftingStatCommand(liftingStats, _userId)).ConfigureAwait(false);
                return Ok(result);
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

        [HttpDelete("{liftingStatId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteLiftingStat(int liftingStatId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteLiftingStatCommand(liftingStatId, _userId)).ConfigureAwait(false);
               return Ok(result);
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
