using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Powerlifting.Common;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        private readonly IMapper _mapper;
        public ExerciseRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            return await PowerliftingContext.Set<Exercise>().AsNoTracking()
                .Include(m => m.ExerciseMuscleGroups)
                .Include(t => t.ExerciseType)
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            return await PowerliftingContext.Set<Exercise>().AsNoTracking()
                .Where(c => c.ExerciseId == id)
                .Include(m => m.ExerciseMuscleGroups)
                .Include(t => t.ExerciseType).AsNoTracking()
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DoesExerciseExist(int exerciseId)
        {
            return await PowerliftingContext.Set<Exercise>()
                .Where(x => x.ExerciseId == exerciseId)
                .AsNoTracking()
                .AnyAsync();
        }

        public async Task<bool> DoesExerciseNameExist(string exerciseName)
        {
            return await PowerliftingContext.Set<Exercise>()
                .Where(x => x.ExerciseName == exerciseName)
                .AsNoTracking()
                .AnyAsync();
        }

        public async Task<bool> UpdateExercise(Exercise exercise)
        {
            return await Update(exercise);
        }

        public async Task<bool> DeleteExercise(Exercise exercise)
        {
            return await Delete(exercise);
        }
    }
}
