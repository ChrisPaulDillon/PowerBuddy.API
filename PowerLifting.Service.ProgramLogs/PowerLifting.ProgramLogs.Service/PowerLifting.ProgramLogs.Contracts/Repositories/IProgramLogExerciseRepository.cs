using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogExerciseRepository
    {

        /// <summary>
        /// Gets a list of program log exercises for a given day
        /// </summary>
        Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId);

        /// <summary>
        /// Gets a given program log exercise
        /// </summary>
        Task<ProgramLogExercise> GetProgramLogExerciseById(int programLogExerciseId);

        Task<bool> DoesExerciseExist(int programLogExerciseId);

        /// <summary>
        /// Creates a new program exercise for a given log, used for customisation of programs
        /// </summary>
        Task<ProgramLogExercise> CreateProgramLogExercise(CProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Marks programLogExercise as complete
        /// rep range etc
        /// </summary>
        Task<bool> MarkProgramLogExerciseComplete(ProgramLogExercise programLogExercise);

        /// <summary>
        /// Updates a program log exercise, this could be updating the number of sets,
        /// the exercise name or adding a comment
        /// </summary>
        Task<bool> UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Used to remove an exercise from the users given program day
        /// </summary>
        Task<bool> DeleteProgramLogExercise(ProgramLogExerciseDTO programLogExercise);

        /// <summary>
        /// Checks if a user already has the exercise they are trying to add on the current day log
        /// </summary>
        Task<int> DoesExerciseExistForDay(int programLogDayId, int exerciseId);

        Task SaveChangesAsync();
    }
}