using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerBuddy.App.Repositories.System;
using PowerBuddy.Data.Dtos.System;

namespace PowerBuddy.API.Areas.Public
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Area("Public")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemRepository _service;

        public SystemController(ISystemRepository service)
        {
            _service = service;
        }

        [HttpGet("Gender")]
        [ProducesResponseType(typeof(IEnumerable<GenderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _service.GetAllGenders();
            return Ok(genders);
        }

        [HttpGet("MemberStatus")]
        [ProducesResponseType(typeof(IEnumerable<GenderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMemberStatus()
        {
            var memberStatus = await _service.GetAllMemberStatus();
            return Ok(memberStatus);
        }

        [HttpGet("LiftingLevel")]
        [ProducesResponseType(typeof(IEnumerable<LiftingLevelDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLiftingLevels()
        {
            var liftingLevels = await _service.GetAllLiftingLevels();
            return Ok(liftingLevels);
        }
    }
}
