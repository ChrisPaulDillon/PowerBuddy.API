using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerlifting.Contracts;
using PowerLifting.Entities.DTOs;

namespace PowerLifting.API.API
{
    [Route("api/LiftingStats")]
    [ApiController]
    public class LiftingStatsController : ControllerBase
    {
        private readonly ILogger<LiftingStatsController> _logger;
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _repository;
        public LiftingStatsController(ILogger<LiftingStatsController> logger, IServiceWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLiftingStats(int id, [FromBody]LiftingStatDTO liftingStats)
        {
            try
            {
                if (liftingStats == null)
                {
                    _logger.LogError("liftingStats object sent from client is null.");
                    return BadRequest("liftingStats object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid liftingStats object sent from client.");
                    return BadRequest("Invalid liftingStats model object");
                }

                liftingStats.LiftingStatId = id;

                var liftingStatsEntity = await _repository.LiftingStat.GetLiftingStatsByIdAsync(id);
                if (liftingStatsEntity == null)
                {
                    _logger.LogError($"liftingStats with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(liftingStats, liftingStatsEntity);

                _repository.LiftingStat.UpdateLiftingStats(liftingStatsEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
