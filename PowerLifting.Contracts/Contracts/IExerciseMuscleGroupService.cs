using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;

namespace PowerLifting.Contracts.Contracts
{
    public interface IExerciseMuscleGroupService
    {
        /// <summary>
        /// Gets all the exercise muscle groups depending if the result has already been cached or not
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExerciseMuscleGroupDTO>> GetAllExerciseMuscleGroups();

        /// <summary>
        /// Gets a speific ExerciseMuscleGroup by id, checks if it exists
        /// </summary>
        /// <param name="exerciseTypeId"></param>
        /// <returns></returns>
        Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseTypeId);

        /// <summary>
        /// Updates a specific ExerciseMuscleGroup object if it exists
        /// </summary>
        /// <param name="exerciseMuscleGroup"></param>
        Task UpdateExerciseMuscleGroup(ExerciseMuscleGroupDTO exerciseMuscleGroup);

        /// <summary>
        /// Deletes a specific ExerciseMuscleGroup object if it exists
        /// </summary>
        /// <param name="exerciseMuscleGroup"></param>
        Task DeleteExerciseMuscleGroup(int exerciseMuscleGroupId);
    }
}