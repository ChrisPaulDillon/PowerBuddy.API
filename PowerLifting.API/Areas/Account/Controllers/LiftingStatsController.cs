using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.MediatR.LiftingStats.Command.Account;
using PowerLifting.MediatR.LiftingStats.Query.Account;

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

        public LiftingStatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<LiftingStatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserLiftingStats()
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var liftingStats = await _mediator.Send(new GetLiftingStatsByUserIdQuery(userId)).ConfigureAwait(false);
                return Ok(Responses.Success(liftingStats));
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateLiftingStat([FromBody] LiftingStatDTO liftingStatDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var liftingStat = await _mediator.Send(new CreateLiftingStatCommand(liftingStatDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(liftingStat));
            }
            catch (LiftingStatAlreadyExistsException e)
            {
                return BadRequest(Responses.Error(e));
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(Responses.Error(e));
            }
        }

        [HttpPut("Collection")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLiftingStatCollection([FromBody] IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var liftingStat = await _mediator.Send(new UpdateLiftingStatCollectionCommand(liftingStatCollectionDTO, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(liftingStat));
            }
            catch (LiftingStatAlreadyExistsException e)
            {
                return BadRequest(Responses.Error(e));
            }
            catch (UnauthorisedUserException e)
            {
                return Unauthorized(Responses.Error(e));
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLiftingStat([FromBody] LiftingStatDTO liftingStats)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new UpdateLiftingStatCommand(liftingStats, userId)).ConfigureAwait(false);
                return Ok(Responses.Success(result));
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
        }

        [HttpDelete("{liftingStatId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteLiftingStat(int liftingStatId)
        {
            try
            {
                var userId = User.Claims.First(x => x.Type == "UserID").Value;
                var result = await _mediator.Send(new DeleteLiftingStatCommand(liftingStatId, userId)).ConfigureAwait(false);
               return Ok(Responses.Success(result));
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch (UnauthorisedUserException ex)
            {
                return Conflict(Responses.Error(ex));
            }
        }
    }
}
