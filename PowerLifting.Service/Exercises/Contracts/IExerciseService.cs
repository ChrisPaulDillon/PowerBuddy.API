using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.Exercises.DTO;

namespace Powerlifting.Service.Exercises.Contracts
{
    public interface IExerciseService 
    {
        IEnumerable<ExerciseDTO> GetAllExercises();
        Task<ExerciseDTO> GetExerciseById(int id);
        void UpdateExercise(ExerciseDTO exercise);
        void DeleteExercise(ExerciseDTO exercise);
        void RefreshExerciseStore();
    }
}
