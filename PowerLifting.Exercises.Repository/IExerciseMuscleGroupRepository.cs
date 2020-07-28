using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Exercises.Repository
{
    public interface IExerciseMuscleGroupRepository
    {
        /// <summary>
        /// Gets all muscle groups such as quads, shoulders, arms etc.
        /// </summary>
        Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups();

        /// <summary>
        /// Get a specific exercise muscle group by id
        /// </summary>
        Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseMuscleGroupId);

        /// <summary>
        /// Updates a specific muscle group object
        /// </summary>
        Task<ExerciseMuscleGroup> CreateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroup);

        /// <summary>
        /// Updates a specific muscle group object
        /// </summary>
        Task<bool> UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroup);

        /// <summary>
        /// Deletes a specific muscle group object
        /// </summary>
        Task<bool> DeleteExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroup);
    }
}