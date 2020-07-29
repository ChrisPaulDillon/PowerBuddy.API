using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Exercises;

namespace PowerLifting.Exercises.Service
{
    public interface IExerciseTypeService
    {
        Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes();
        Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId);
        Task<bool> UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO);
        Task<bool> DeleteExerciseType(ExerciseTypeDTO exerciseTypeDTO);
        Task<ExerciseTypeDTO> CreateExerciseType(ExerciseTypeDTO exerciseTypeDTO);
    }
}