using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs.Lookups;

namespace Powerlifting.Service.ExerciseCategories
{
    public interface IExerciseCategoryService
    {
        IEnumerable<ExerciseCategoryDTO> GetAllCategories();
        Task<ExerciseCategoryDTO> GetExerciseCategoryById(int id);
        Task<ExerciseCategoryDTO> GetExerciseCategoryByName(string name);
        void UpdateExerciseCategory(ExerciseCategoryDTO exerciseCategory);
        void DeleteExerciseCategory(ExerciseCategoryDTO exerciseCategory);
    }
}
