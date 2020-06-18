using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface IExerciseTypeService
    {
        Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes();
        Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId);
        Task<bool> UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO);
        Task<bool> DeleteExerciseType(int exerciseTypeId);
    }
}