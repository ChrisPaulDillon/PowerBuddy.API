using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Exceptions;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users.Exceptions;

namespace PowerLifting.API.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public LiftingStatsController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserLiftingStats(string userId)
        {
            try
            {
                var liftingStats = await _service.LiftingStat.GetLiftingStatByUserId(userId);
                return Ok(liftingStats);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateLiftingStats(string userId, [FromBody]LiftingStatDTO liftingStats)
        {
            try
            {
                _service.LiftingStat.UpdateLiftingStatsAsync(userId, liftingStats);
            }
            catch(LiftingStatNotFoundException e)
            {
                return NotFound(e);
            }
            catch(UserDoesNotMatchLiftingStatException e)
            {
                return NotFound(e);
            }
            return NoContent();
        }
    }
}
