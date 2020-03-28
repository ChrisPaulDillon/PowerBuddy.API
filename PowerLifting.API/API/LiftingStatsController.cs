using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Service.LiftingStats.DTO;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftingStatsController : ControllerBase
    {
        private readonly ILogger<LiftingStatsController> _logger;
        private readonly IServiceWrapper _repository;

        public LiftingStatsController(IServiceWrapper repository, ILogger<LiftingStatsController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLiftingStats(int id, [FromBody]LiftingStatDTO liftingStats)
        {

            if (liftingStats == null)
            {
                return BadRequest("liftingStats object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid liftingStats model object");
            }

            liftingStats.LiftingStatId = id;

            //var liftingStatsEntity = await _repository.LiftingStat.GetLiftingStatsByIdAsync(id);
            //if (liftingStatsEntity == null)
            //{
            //    return NotFound();
            //}

            //_repository.LiftingStat.UpdateLiftingStats(liftingStats);
            return NoContent();
        }  
    }
}
