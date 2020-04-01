using System.Security.Claims;
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
        private readonly UserManager<User> _userManager;
        private readonly User _userLoggedIn;

        public LiftingStatsController(IServiceWrapper service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager
                var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userLoggedIn = await _userManager.GetUserAsync(HttpContext.User);
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
