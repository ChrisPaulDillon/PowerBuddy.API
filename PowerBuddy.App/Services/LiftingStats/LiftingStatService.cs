using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Services.LiftingStats
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

        public async Task<IDictionary<Tuple<int,int>, LiftingStatAudit>> GetPersonalBestsForRepRangeAndExercise(IList<int> repRanges, int exerciseId, string userId)
        {

            var parameters = new string[repRanges.Count + 1];
            var sqlParameters = new List<SqlParameter>();
            for (var i = 0; i < repRanges.Count; i++)
            {
                parameters[i] = string.Format("@p{0}", i);
                sqlParameters.Add(new SqlParameter(parameters[i], repRanges[i]));
            }

            var rawCommand =
                $@"SELECT t.LiftingStatAuditId, t.UserId, t.RepRange, t.Weight, t.ExerciseId, t.DateChanged, t.WorkoutSetId FROM(SELECT RepRange, ExerciseId, UserId, MAX(weight) as weightMax FROM LiftingStatAudit GROUP BY RepRange, ExerciseId, UserId HAVING RepRange IN ({string.Join(", ", parameters)})";

            var index = rawCommand.LastIndexOf(',');
            var fixedCmd = rawCommand.Remove(index, 1);
            var rawCommand2 = string.Format($"AND UserId = '{userId}' AND ExerciseId = {exerciseId}) AS m INNER JOIN LiftingStatAudit AS t ON t.RepRange = m.RepRange AND t.Weight = weightMax WHERE t.ExerciseId = {exerciseId}");

            var completeSqlCmd = fixedCmd + rawCommand2;

            return await _context.LiftingStatAudit
                .FromSqlRaw(completeSqlCmd, sqlParameters.ToArray())
                .AsNoTracking()
                .ToDictionaryAsync(x => new Tuple<int, int>(x.ExerciseId, x.RepRange), x => x);

            //return await _context.LiftingStatAudit
            //    .Where(x => repRanges.Any(j => j == x.RepRange) && x.ExerciseId == exerciseId && x.UserId == userId)
            //    .GroupBy(x => x.RepRange)
            //    .Select(x => new TestModel()
            //    {
            //        RepRange = x.Key, 
            //        MaxWeightPersonalBest = x
            //    })
            //    .ToListAsync();
        }

        public async Task<IEnumerable<LiftingStatAuditDTO>> GetTopLiftingStatForExercise(int exerciseId, string userId)
        {
            var stats = await _context.LiftingStatAudit.AsNoTracking()
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .ProjectTo<LiftingStatAuditDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var groupedStats = stats.GroupBy(x => new { x.RepRange, x.ExerciseId })
                .Select(x => x.OrderByDescending(x => x.Weight).FirstOrDefault())
                .ToList();

            return groupedStats;
        }

        public async Task<IEnumerable<LiftingStatAuditDTO>> GetTopLiftingStatCollection(string userId)
        {
            var stats = await _context.LiftingStatAudit.AsNoTracking()
                .Where(x => x.UserId == userId)
                .ProjectTo<LiftingStatAuditDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var groupedStats = stats.GroupBy(x => new { x.RepRange, x.ExerciseId })
                .Select(x => x.OrderByDescending(x => x.Weight).FirstOrDefault())
                .ToList();

            return groupedStats;
        }
    }
}
