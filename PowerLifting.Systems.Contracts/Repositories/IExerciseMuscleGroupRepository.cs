using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;

namespace PowerLifting.Systems.Contracts.Repositories
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