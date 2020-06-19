using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface IExerciseMuscleGroupService
    {
        /// <summary>
        /// Gets all the exercise muscle groups depending if the result has already been cached or not
        /// </summary>
        Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups();

        /// <summary>
        /// Updates a specific ExerciseMuscleGroup object if it exists
        /// </summary>
        Task<bool> UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO);

        /// <summary>
        /// Deletes a specific ExerciseMuscleGroup object if it exists
        /// </summary>
        Task<bool> DeleteExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroupDTO);
    }
}