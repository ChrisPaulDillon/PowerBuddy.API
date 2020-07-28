using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Exercises.Repository
{
    public interface IExerciseTypeRepository
    {
        /// <summary>
        /// Gets all exercise types such as bodyweight, dumbbell, barbell etc.
        /// </summary>
        Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes();

        /// <summary>
        /// Gets a specific exercise type by id
        /// </summary>
        Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId);

        /// <summary>
        /// Creates a new exerciseType
        /// </summary>
        Task<ExerciseType> CreateExerciseType(ExerciseTypeDTO exerciseCategoryDTO);

        /// <summary>
        /// Updates a given exercise object
        /// </summary>
        Task<bool> UpdateExerciseType(ExerciseTypeDTO exerciseCategoryDTO);

        /// <summary>
        /// Deletes an exercise type object
        /// </summary>
        Task<bool> DeleteExerciseType(ExerciseTypeDTO exerciseCategoryDTO);
    }
}