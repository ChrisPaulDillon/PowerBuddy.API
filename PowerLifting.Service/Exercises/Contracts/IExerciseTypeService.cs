using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.Exercises.DTO;

namespace PowerLifting.Service.Exercises.Contracts
{
    public interface IExerciseTypeService
    {
        Task<IEnumerable<ExerciseTypeDTO>> GetAllExerciseTypes();
        Task<ExerciseTypeDTO> GetExerciseTypeById(int exerciseTypeId);
        Task UpdateExerciseType(ExerciseTypeDTO exerciseTypeDTO);
        Task DeleteExerciseType(int exerciseTypeId);
    }
}