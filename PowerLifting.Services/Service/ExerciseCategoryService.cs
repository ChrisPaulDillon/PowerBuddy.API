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
    public class ExerciseCategoryService : ServiceBase<ExerciseCategory>, IExerciseCategoryService
    {
        public ExerciseCategoryService(PowerliftingContext ServiceContext)
            : base(ServiceContext)
        {
        }

        public async Task<ExerciseCategory> GetExerciseCategoryById(int id)
        {
            return await PowerliftingContext.Set<ExerciseCategory>().Where(exerciseCategory => exerciseCategory.ExerciseCategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<ExerciseCategory> GetExerciseCategoryByName(string categoryName)
        {
            return await PowerliftingContext.Set<ExerciseCategory>().Where(exerciseCategory => exerciseCategory.CategoryName == categoryName).FirstOrDefaultAsync();
        }

        public void UpdateExerciseCategory(ExerciseCategory exerciseCategory)
        {
            Update(exerciseCategory);
        }

        public void DeleteExerciseCategory(ExerciseCategory exerciseCategory)
        {
            Delete(exerciseCategory);
        }
    }
}
