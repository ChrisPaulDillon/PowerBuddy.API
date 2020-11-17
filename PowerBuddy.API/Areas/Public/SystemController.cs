using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Services.System;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService _service;

        public SystemController(ISystemService service)
        {
            _service = service;
        }

        [HttpGet("Gender")]
        [ProducesResponseType(typeof(IEnumerable<GenderDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _service.GetAllGenders();
            return Ok(genders);
        }

        [HttpGet("MemberStatus")]
        [ProducesResponseType(typeof(IEnumerable<GenderDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMemberStatus()
        {
            var memberStatus = await _service.GetAllMemberStatus();
            return Ok(memberStatus);
        }

        [HttpGet("LiftingLevel")]
        [ProducesResponseType(typeof(IEnumerable<LiftingLevelDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLiftingLevels()
        {
            var liftingLevels = await _service.GetAllLiftingLevels();
            return Ok(liftingLevels);
        }
    }
}
