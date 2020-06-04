using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await PowerliftingContext.Set<Exercise>().AsNoTracking().Include(m => m.ExerciseMuscleGroups)
                                                                                           .Include(t => t.ExerciseType).ToListAsync();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            return await PowerliftingContext.Set<Exercise>().Where(c => c.ExerciseId == id).Include(m => m.ExerciseMuscleGroups)
                                                                                           .Include(t => t.ExerciseType).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Exercise> GetExerciseByName(string exerciseName)
        {
            return await PowerliftingContext.Set<Exercise>().Where(c => c.ExerciseName == exerciseName).Include(m => m.ExerciseMuscleGroups)
                                                                                           .Include(t => t.ExerciseType).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExerciseByExerciseTypeId(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<Exercise>().Where(c => c.ExerciseTypeId == exerciseTypeId).Include(m => m.ExerciseMuscleGroups)
                                                                                           .Include(t => t.ExerciseType).AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<Exercise>> GetExerciseByExerciseMuscleGroupId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateExercise(Exercise exercise)
        {
            Update(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            Delete(exercise);
        }
    }
}
