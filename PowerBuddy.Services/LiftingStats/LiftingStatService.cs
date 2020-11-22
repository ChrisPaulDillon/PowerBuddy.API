using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.LiftingStats.Models;

namespace PowerBuddy.Services.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public LiftingStatService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateLiftingStatAudit(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId)
        {
            var liftingStatAudit = new LiftingStatAudit()
            {
                ExerciseId = exerciseId,
                RepRange = repRange,
                Weight = weight,
                UserId = userId,
                DateChanged = DateTime.UtcNow
            };

            _context.LiftingStatAudit.Add(liftingStatAudit);
        }

        public IEnumerable<TemplateWeightInputDTO> CalculateNewWeightInput(IEnumerable<TemplateWeightInputDTO> weightInputs, Dictionary<int, decimal> weightIncrements)
        {
            foreach (var weightInput in weightInputs)
            {
                var weightIncrement = weightIncrements[weightInput.ExerciseId];
                weightInput.Weight = weightInput.Weight + weightIncrement;
            }

            return weightInputs;
        }

        public async Task<LiftingStatAudit> GetTopLiftingStatForRepRange(int repRange, int exerciseId, string userId)
        {
            return await _context.LiftingStatAudit
                .Where(x => x.RepRange == repRange && x.ExerciseId == exerciseId && x.UserId == userId)
                .OrderByDescending(x => x.Weight)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LiftingStatAudit>> GetTopLiftingStatForExercise(int exerciseId, string userId)
        {
            return await _context.LiftingStatAudit.Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .GroupBy(x => x.RepRange)
                .Select(g => g.OrderByDescending(x => x.Weight).First())
                .ToListAsync();
        }

        public async Task<IEnumerable<LiftingStatAuditDTO>> GetTopLiftingStatCollection(string userId)
        {
            var stats = await _context.LiftingStatAudit.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();

            var groupedStats = stats.GroupBy(x => new { x.RepRange, x.ExerciseId })
                .Select(x => x.OrderByDescending(x => x.Weight).FirstOrDefault())
                .ToList();

            var mappedStats = _mapper.Map<IEnumerable<LiftingStatAuditDTO>>(groupedStats);

            return mappedStats;
        }
    }
}
