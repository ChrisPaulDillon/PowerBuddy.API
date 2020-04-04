using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Service.Exercises.DTO;

namespace Powerlifting.Service.Exercises.Contracts
{
    public interface IExerciseService 
    {
        /// <summary>
        /// Gets a top level overview of all exercises available
        /// </summary>
        /// <returns></returns>
        IEnumerable<TopLevelExerciseDTO> GetAllExercises();

        /// <summary>
        /// Gets a specific exercise by id and includes its type and muscle groups worked
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExerciseDTO> GetExerciseById(int id);

        /// <summary>
        /// Gets all exercises that fall under a specific muscle group such as quads, biceps etc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesByMuscleGroupId(int id);

        /// <summary>
        /// Gets all exercises that fall under a certain exercise type such as bodyweight, barbell etc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesByExerciseTypeId(int id);

        void UpdateExercise(ExerciseDTO exercise);
        void DeleteExercise(ExerciseDTO exercise);
        void RefreshExerciseStore();
    }
}
