using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogExerciseRepository : IRepositoryBase<ProgramLogExercise>
    {

        /// <summary>
        /// Gets a list of program log exercises for a given day
        /// </summary>
        /// <param name="programLogDayId"></param>
        Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId);

        /// <summary>
        /// Gets a given program log exercise
        /// </summary>
        /// <param name="programLogExerciseId"></param>
        /// <returns></returns>
        Task<ProgramLogExerciseDTO> GetProgramLogExerciseById(int programLogExerciseId);

        Task<bool> DoesExerciseExist(int programLogExerciseId);

        /// <summary>
        /// Creates a new program exercise for a given log, used for customisation of programs
        /// </summary>
        Task CreateProgramLogExercise(ProgramLogExercise programLogExercise);

        /// <summary>
        /// Updates a program log exercise, this could be updating the number of sets,
        /// the exercise name or adding a comment
        /// </summary>
        Task<bool> UpdateProgramLogExercise(ProgramLogExercise programLogExercise);

        /// <summary>
        /// Used to remove an exercise from the users given program day
        /// </summary>
        Task<bool> DeleteProgramLogExercise(ProgramLogExercise programLogExercise);
    }
}