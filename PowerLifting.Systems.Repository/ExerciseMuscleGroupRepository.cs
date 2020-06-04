using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;

namespace PowerLifting.Systems.Repository
{
    public class ExerciseMuscleGroupRepository : RepositoryBase<ExerciseMuscleGroup>, IExerciseMuscleGroupRepository
    {

        public ExerciseMuscleGroupRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExerciseMuscleGroup>> GetAllExerciseMuscleGroups()
        {
            return await PowerliftingContext.Set<ExerciseMuscleGroup>().AsNoTracking().ToListAsync();
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
