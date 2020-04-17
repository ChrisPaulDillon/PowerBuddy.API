using System.Threading.Tasks;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using PowerLifting.ProgramLogExercises.Model;

namespace PowerLifting.Service.ProgramLogExercises
{
    public interface IProgramLogExerciseRepository : IRepositoryBase<ProgramLogExercise>
    {
        /// <summary>
        /// Allows the user to add another set / rep onto a given exercise
        /// </summary>
        /// <param name="programLogRepScheme"></param>
        /// <returns></returns>
        Task CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);

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
