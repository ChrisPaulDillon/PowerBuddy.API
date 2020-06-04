using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Entity.System.ExerciseTypes.Models;

namespace PowerLifting.Repository.Exercises
{
    public class ExerciseTypeRepository : RepositoryBase<ExerciseType>, IExerciseTypeRepository
    {
        public ExerciseTypeRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExerciseType>> GetAllExerciseTypes()
        {
            return await PowerliftingContext.Set<ExerciseType>().AsNoTracking().ToListAsync();
        }

        public async Task<ExerciseType> GetExerciseTypeById(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<ExerciseType>().Where(c => c.ExerciseTypeId == exerciseTypeId).FirstOrDefaultAsync();
        }

        public void UpdateExerciseType(ExerciseType exerciseType)
        {
            Update(exerciseType);
        }

        public void DeleteExerciseType(ExerciseType exerciseType)
        {
            Delete(exerciseType);
        }
    }
}
