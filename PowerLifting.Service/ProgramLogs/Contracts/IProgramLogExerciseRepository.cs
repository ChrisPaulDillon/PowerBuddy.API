using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogExerciseRepository : IRepositoryBase<ProgramLogExercise>
    {

        /// <summary>
        /// Gets a given program log exercise
        /// </summary>
        /// <param name="programLogExerciseId"></param>
        /// <returns></returns>
        Task<ProgramLogExercise> GetProgramLogExercise(int programLogExerciseId);

        /// <summary>
        /// Creates a new program exercise for a given log, used for customisation of programs
        /// </summary>
        /// <param name="programLogExercise"></param>
        void CreateProgramLogExercise(ProgramLogExercise programLogExercise);

        /// <summary>
        /// Updates a program log exercise, this could be updating the number of sets,
        /// the exercise name or adding a comment
        /// </summary>
        /// <param name="programLogExercise"></param>
        void UpdateProgramLogExercise(ProgramLogExercise programLogExercise);

        /// <summary>
        /// Used to remove an exercise from the users given program day
        /// </summary>
        /// <param name="programLogExercise"></param>
        void DeleteProgramLogExercise(ProgramLogExercise programLogExercise);
    }
}