using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.DTO;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseMuscleGroupService
    {
        IEnumerable<ExerciseMuscleGroupDTO> GetAllExerciseMuscleGroups();
        Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseTypeId);
        void UpdateExerciseType(ExerciseMuscleGroupDTO exerciseMuscleGroup);
        void DeleteExerciseType(ExerciseMuscleGroupDTO exerciseMuscleGroup);
    }
}
