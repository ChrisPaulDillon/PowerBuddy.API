using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Repository.Exercises
{
    public class ExerciseMuscleGroupRepository : RepositoryBase<ExerciseMuscleGroup>, IExerciseMuscleGroupRepository
    {

        public ExerciseMuscleGroupRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExerciseMuscleGroup>> GetAllExerciseMuscleGroups()
        {
            return await PowerliftingContext.Set<ExerciseMuscleGroup>().ToListAsync();
        }

        public async Task<ExerciseMuscleGroup> GetExerciseMuscleGroupById(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<ExerciseMuscleGroup>().Where(c => c.ExerciseMuscleGroupId == exerciseTypeId).FirstOrDefaultAsync();
        }

        public void UpdateExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            Update(exerciseMuscleGroup);
        }

        public void DeleteExerciseMuscleGroup(ExerciseMuscleGroup exerciseMuscleGroup)
        {
            Delete(exerciseMuscleGroup);
        }
    }
}
