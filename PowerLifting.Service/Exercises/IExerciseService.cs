using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;

namespace Powerlifting.Service.Exercises
{
    public interface IExerciseService 
    {
        IEnumerable<ExerciseDTO> GetAllExercises();
        Task<ExerciseDTO> GetExerciseById(int id);
        Task<ExerciseDTO> GetExerciseByName(string name);
        void UpdateExercise(ExerciseDTO exercise);
        void DeleteExercise(ExerciseDTO exercise);
        void RefreshExerciseStore();
    }
}
