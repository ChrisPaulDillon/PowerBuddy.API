using System;
using System.Threading.Tasks;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogExerciseAuditRepository
    {
        Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId);

        /// <summary>
        /// Used to retrieve the potential audit when a user
        /// creates a new program log exercise
        /// </summary>
        Task<ProgramLogExerciseAudit> GetProgramLogExerciseAudit(string userId, int exerciseId);

        /// <summary>
        /// Used to create an program log exercise audit
        /// when the user does not currently have one
        /// for this exercise
        /// </summary>
        Task<int> CreateProgramLogExerciseAudit(ProgramLogExerciseAudit audit);

    }
}
