using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using PowerLifting.Entities.DTOs.Lookups;

namespace Powerlifting.Service.Exercises
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
