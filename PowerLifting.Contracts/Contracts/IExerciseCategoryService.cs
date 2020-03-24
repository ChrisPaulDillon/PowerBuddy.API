using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;

namespace Powerlifting.Contracts.Contracts
{
    public interface IExerciseCategoryService : IServiceBase<ExerciseCategory>
    {
        Task<ExerciseCategory> GetExerciseCategoryById(int id);
        Task<ExerciseCategory> GetExerciseCategoryByName(string categoryName);
        void UpdateExerciseCategory(ExerciseCategory exerciseCategory);
        void DeleteExerciseCategory(ExerciseCategory exerciseCategory);
    }
}
