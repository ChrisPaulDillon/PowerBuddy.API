using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ExerciseCategories.Model;

namespace PowerLifting.Services.ExerciseCategories
{
    public interface IExerciseCategoryRepository
    {
        Task<IEnumerable<ExerciseCategory>> GetAllCategories();
        Task<ExerciseCategory> GetCategoryById(int id);
        void UpdateCategory(ExerciseCategory category);
        void DeleteCategory(ExerciseCategory category);
    }
}
