using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;

namespace Powerlifting.Contracts.Contracts
{
    public interface IExerciseCategoryService : IServiceBase<ExerciseCategory>
    {
        Task<ExerciseCategoryDTO> GetExerciseCategoryById(int id);
        Task<ExerciseCategoryDTO> GetExerciseCategoryByName(string categoryName);
        void UpdateExerciseCategory(ExerciseCategory exerciseCategory);
        void DeleteExerciseCategory(ExerciseCategory exerciseCategory);
    }
}
