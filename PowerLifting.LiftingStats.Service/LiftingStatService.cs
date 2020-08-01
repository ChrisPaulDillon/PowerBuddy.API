using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.Persistence;

namespace PowerLifting.LiftingStats.Service
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

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserId(string userId)
        {
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId && u.RepRange == repRange && u.Weight != null)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> CreateLiftingStatsByAthleteType(string userId, IEnumerable<TopLevelExerciseDTO> exercises)
        {
            var repRanges = new int[] { 1, 2, 3, 5, 10 };
            var exerciseList = exercises.ToList();
            foreach (var exercise in exerciseList)
            {
                foreach (var repRange in repRanges)
                {
                    _context.Add(
                    new LiftingStat()
                        {
                            UserId = userId,
                            ExerciseId = exercise.ExerciseId,
                            RepRange = repRange,
                            LastUpdated = DateTime.UtcNow
                        });
                }
            }

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<LiftingStatDTO> CreateLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var userId = liftingStatDTO.UserId;
            var repRange = liftingStatDTO.RepRange;

            var doesLiftingStatExist = await _context.LiftingStat.Where(x => x.UserId == userId && x.ExerciseId == liftingStatDTO.ExerciseId && x.RepRange == repRange)
                .AsNoTracking()
                .AnyAsync();

            if (doesLiftingStatExist) throw new LiftingStatAlreadyExistsException();

            var createdLiftingStat = new LiftingStat()
            {
                UserId = liftingStatDTO.UserId,
                ExerciseId = liftingStatDTO.ExerciseId,
                RepRange = liftingStatDTO.RepRange,
                Weight = liftingStatDTO.Weight,
                GoalWeight = liftingStatDTO.GoalWeight,
                PercentageToGoal = liftingStatDTO.GoalWeight != null ? (liftingStatDTO.Weight / liftingStatDTO.GoalWeight) * 100 : null,
                LastUpdated = liftingStatDTO.LastUpdated,
            };

            _context.Add(createdLiftingStat);

            createdLiftingStat.Exercise = new Exercise()
            {
                ExerciseId = liftingStatDTO.Exercise.ExerciseId,
                ExerciseName = liftingStatDTO.Exercise.ExerciseName
            };

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.UtcNow,
                RepRange = liftingStatDTO.RepRange,
                ExerciseId = liftingStatDTO.ExerciseId,
                UserId = liftingStatDTO.UserId,
            };
            //var createdAudit = await _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);

            return liftingStatDTO;
        }

        public async Task<bool> UpdateLiftingStat(LiftingStatDTO stats)
        {
            var liftingStat = await _context.LiftingStat.Where(x => x.LiftingStatId == stats.LiftingStatId).AsNoTracking().AnyAsync();
            if (!liftingStat) throw new LiftingStatNotFoundException();

            var liftingStatEntity = _mapper.Map<LiftingStat>(stats);
            _context.Update(liftingStatEntity);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.Now.Date,
                RepRange = stats.RepRange,
                UserId = stats.UserId,
                ExerciseId = stats.ExerciseId
            };

            _context.Add(liftingStatAudit);

            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }

        public async Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var liftingStat = await _context.LiftingStat.Where(x => x.LiftingStatId == liftingStatDTO.LiftingStatId).AsNoTracking().AnyAsync();
            if (!liftingStat) throw new LiftingStatNotFoundException();

            var liftingStatEntity = _mapper.Map<LiftingStat>(liftingStatDTO);
            _context.Remove(liftingStatEntity);

            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }

        public async Task<bool> UpdateLiftingStatCollection(IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
            var liftingStatCollection = _mapper.Map<LiftingStat>(liftingStatCollectionDTO);
            _context.LiftingStat.Attach(liftingStatCollection);
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}