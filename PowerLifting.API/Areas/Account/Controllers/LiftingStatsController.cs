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
        private string _userId = "";

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
                _userId = User.Claims.First(x => x.Type == "UserID").Value;
                var liftingStats = await _mediator.Send(new GetLiftingStatsByUserIdQuery(_userId)).ConfigureAwait(false);
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
        public async Task<IActionResult> CreateLiftingStat([FromBody] LiftingStatDTO liftingStatDTO)
        {
            try
            {//TODO ADD USER VALIDATION
                var liftingStat = await _mediator.Send(new CreateLiftingStatCommand(liftingStatDTO)).ConfigureAwait(false);
                return Ok(Responses.Success(liftingStat));
            }
            catch (LiftingStatAlreadyExistsException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpPut("Collection")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLiftingStatCollection([FromBody] IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
            try
            {
                var liftingStat = await _mediator.Send(new UpdateLiftingStatCollectionCommand(liftingStatCollectionDTO)).ConfigureAwait(false);
                return Ok(Responses.Success(liftingStat));
            }
            catch (LiftingStatAlreadyExistsException ex)
            {
                return BadRequest(Responses.Error(ex));
            }
        }

        [HttpPut("{liftingStatId:int}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLiftingStat(int liftingStatId, [FromBody] LiftingStatDTO liftingStats)
        {
            try
            {
                var isUpdated = await _mediator.Send(new UpdateLiftingStatCommand(liftingStats)).ConfigureAwait(false);
                return Ok(Responses.Success(isUpdated));
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
        public async Task<IActionResult> DeleteLiftingStatAsync(int liftingStatId)
        {
            try
            {
               var result = await _mediator.Send(new DeleteLiftingStatCommand(liftingStatId)).ConfigureAwait(false);
               return Ok(Responses.Success(result));
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
        }
    }
}
