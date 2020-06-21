using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.API.Wrappers;
using PowerLifting.Common.Exceptions;
using PowerLifting.LiftingStats.Service.Exceptions;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.API.API
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public LiftingStatsController(IServiceWrapper service)
        {
            _service = service;
        }


        [HttpGet("{userId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<LiftingStatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserLiftingStats(string userId)
        {
            try
            {
                var liftingStats = await _service.LiftingStat.GetLiftingStatsByUserId(userId);
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
            {
                var liftingStat = await _service.LiftingStat.CreateLiftingStat(liftingStatDTO);
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
                var isUpdated = await _service.LiftingStat.UpdateLiftingStat(liftingStats);
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
        public IActionResult DeleteLiftingStat(int liftingStatId)
        {
            try
            {
                _service.LiftingStat.DeleteLiftingStat(new LiftingStatDTO() { LiftingStatId = liftingStatId });
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            return Ok(Responses.Success());
        }
    }
}
