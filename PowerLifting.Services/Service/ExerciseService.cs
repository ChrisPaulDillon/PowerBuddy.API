using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;
using Powerlifting.Services;
using System.Collections.Generic;
using PowerLifting.Entities.Model.Lookups;
using Powerlifting.Contracts;
using System.Linq.Expressions;
using System;

namespace Powerlifting.Services.Service
{
    public class ExerciseService : ServiceBase<Exercise>, IExerciseService
    {
        public ExerciseService(PowerliftingContext ServiceContext)
            : base(ServiceContext)
        {
        }

        public async Task<Exercise> GetExerciseByName(string exercise)
        {
            return await PowerliftingContext.Set<Exercise>().Where(Exercise => Exercise.ExerciseName == exercise).FirstOrDefaultAsync();
        }

        public async Task<List<Exercise>> GetAllIncludeCategories()
        {
            return await PowerliftingContext.Set<Exercise>().Include(x => x.ExerciseCategory).ToListAsync();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            return await PowerliftingContext.Set<Exercise>().Include(x => x.ExerciseCategory).AsNoTracking().FirstOrDefaultAsync();
        }

        public void UpdateExercie(Exercise exercise)
        {
            Update(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            Delete(exercise);
        }
    }
}
