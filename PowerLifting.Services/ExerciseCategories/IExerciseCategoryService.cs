using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.ServiceWrappers;
using PowerLifting.Entities.DTOs.Lookups;

namespace Powerlifting.Service.ExerciseCategories
{
    public interface IExerciseCategoryService : IServiceBase<ExerciseCategory>
    {
        IEnumerable<ExerciseCategoryDTO> GetAllCategories();
        Task<ExerciseCategoryDTO> GetExerciseCategoryById(int id);
        Task<ExerciseCategoryDTO> GetExerciseCategoryByName(string categoryName);
        void UpdateExerciseCategory(ExerciseCategory exerciseCategory);
        void DeleteExerciseCategory(ExerciseCategory exerciseCategory);
    }
}
