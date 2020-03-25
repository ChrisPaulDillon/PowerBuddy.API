using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Entities.Model.Lookups;

namespace Powerlifting.Contracts.Contracts
{
    public interface IExerciseService : IServiceBase<Exercise>
    {
        IEnumerable<ExerciseDTO> GetAllExercises();
        Task<ExerciseDTO> GetExerciseById(int id);
        Task<ExerciseDTO> GetExerciseByName(string name);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
        void RefreshExerciseStore();

    }
}
