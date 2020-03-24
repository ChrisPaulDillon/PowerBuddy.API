using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.Model.Lookups;

namespace Powerlifting.Contracts.Contracts
{
    public interface IExerciseService : IServiceBase<Exercise>
    {
        Task<List<Exercise>> GetAllIncludeCategories();
        Task<Exercise> GetExerciseById(int id);
        Task<Exercise> GetExerciseByName(string name);
        void UpdateExercie(Exercise exercise);
        void DeleteExercise(Exercise exercise);

    }
}
