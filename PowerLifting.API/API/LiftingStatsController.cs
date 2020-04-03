using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Powerlifting.Service.LiftingStats.DTO;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.API.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public LiftingStatsController(IServiceWrapper service, UserManager<User> userManager)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLiftingStats(int id, [FromBody]LiftingStatDTO liftingStats)
        {
            if (liftingStats == null) return BadRequest("liftingStats object is null");
            if (!ModelState.IsValid) return BadRequest("Invalid liftingStats model object");
         
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
