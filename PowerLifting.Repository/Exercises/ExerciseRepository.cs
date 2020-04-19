using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.Exercises.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Repository.Exercises
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(PowerliftingContext context) : base(context)
        {
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return PowerliftingContext.Set<Exercise>().ToList();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            return await PowerliftingContext.Set<Exercise>().Where(c => c.ExerciseId == id).Include(m => m.ExerciseMuscleGroups)
                                                                                           .Include(t => t.ExerciseType).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExerciseByExerciseTypeId(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<Exercise>().Where(c => c.ExerciseTypeId == exerciseTypeId).Include(m => m.ExerciseMuscleGroups)
                                                                                           .Include(t => t.ExerciseType).ToListAsync();
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
