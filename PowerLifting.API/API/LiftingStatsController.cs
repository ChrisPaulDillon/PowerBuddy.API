using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.API.Models;
using PowerLifting.Service;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Exceptions;
using PowerLifting.Service.Users.Exceptions;

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
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<LiftingStatDTO>>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(typeof(ApiResponse<bool>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLiftingStatAsync([FromBody] CreateLiftingStatDTO liftingStatDTO)
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

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<bool>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateLiftingStat([FromBody]LiftingStatDTO liftingStats)
        {
            try
            {
                _service.LiftingStat.UpdateLiftingStat(liftingStats);
            }
            catch(LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            catch(UnauthorisedUserException ex)
            {
                return Unauthorized(Responses.Error(ex));
            }
            return Ok(Responses.Success());
        }

        [HttpDelete("{liftingStatId}")]
        [ProducesResponseType(typeof(ApiResponse<bool>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<ApiError>),StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteLiftingStat(int liftingStatId)
        {
            try
            {
                _service.LiftingStat.DeleteLiftingStat(liftingStatId);
            }
            catch (LiftingStatNotFoundException ex)
            {
                return NotFound(Responses.Error(ex));
            }
            return Ok(Responses.Success());
        }
    }
}
