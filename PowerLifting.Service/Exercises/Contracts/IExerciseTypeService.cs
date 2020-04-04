using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.DTO;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseTypeService
    {
        IEnumerable<ExerciseTypeDTO> GetAllExerciseTypes();
        Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId);
        void UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO);
        void DeleteExerciseType(ExerciseTypeDTO exerciseTypeDTO);
    }
}
