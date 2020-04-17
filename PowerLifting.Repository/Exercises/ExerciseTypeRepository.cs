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
    public class ExerciseTypeRepository : RepositoryBase<ExerciseType>, IExerciseTypeRepository
    {
        public ExerciseTypeRepository(PowerliftingContext context) : base(context)
        {
        }

        public IEnumerable<ExerciseType> GetAllExerciseTypes()
        {
            return PowerliftingContext.Set<ExerciseType>().ToList();
        }

        public async Task<ExerciseType> GetExerciseTypeById(int exerciseTypeId)
        {
            return await PowerliftingContext.Set<ExerciseType>().Where(c => c.ExerciseTypeId == exerciseTypeId).FirstOrDefaultAsync();
        }

        public void UpdateExerciseType(ExerciseType exerciseType)
        {
            Update(exerciseType);
            Save();
        }

        public void DeleteExerciseType(ExerciseType exerciseType)
        {
            Delete(exerciseType);
            Save();
        }
    }
}
