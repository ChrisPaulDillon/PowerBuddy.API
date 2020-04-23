﻿using System.Threading.Tasks;
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
    [Produces("application/json")]
    public class LiftingStatsController : ControllerBase
    {
        private readonly IServiceWrapper _service;

        public LiftingStatsController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUserLiftingStats(string userId)
        {
            try
            {
                var liftingStats = await _service.LiftingStat.GetLiftingStatsByUserId(userId);
                return Ok(liftingStats);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLiftingStat([FromBody] LiftingStatDTO liftingStat)
        {
            try
            {
                await _service.LiftingStat.CreateLiftingStats(liftingStat);
                return Ok();
            }
            catch (LiftingStatRepRangeAlreadyExistsException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateLiftingStats ([FromBody]LiftingStatDTO liftingStats)
        {
            try
            {
                _service.LiftingStat.UpdateLiftingStat(liftingStats);
            }
            catch(LiftingStatNotFoundException e)
            {
                return NotFound(e);
            }
            catch(UserDoesNotMatchLiftingStatException e)
            {
                return Unauthorized(e);
            }
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteLiftingStat([FromBody]LiftingStatDTO liftingStats)
        {
            try
            {
                _service.LiftingStat.DeleteLiftingStat(liftingStats);
            }
            catch (LiftingStatNotFoundException e)
            {
                return NotFound(e);
            }
            return NoContent();
        }
    }
}
