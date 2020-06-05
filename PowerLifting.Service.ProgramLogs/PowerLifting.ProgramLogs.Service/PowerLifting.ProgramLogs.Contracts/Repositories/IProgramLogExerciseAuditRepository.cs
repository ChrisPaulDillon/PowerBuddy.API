using System;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogExerciseAuditRepository : IRepositoryBase<ProgramLogExerciseAudit>
    {
        /// <summary>
        /// Used to retrieve the potential audit when a user
        /// creates a new program log exercise
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="programLogId"></param>
        /// <param name="dateSelected"></param>
        /// <returns></returns>
        Task<ProgramLogExerciseAudit> GetProgramLogExerciseAudit(string userId, int exerciseId);

        /// <summary>
        /// Used to create an program log exercise audit
        /// when the user does not currently have one
        /// for this exercise
        /// </summary>
        /// <returns></returns>
        void CreateProgramLogExerciseAudit(ProgramLogExerciseAudit audit);

        void UpdateProgramLogExerciseAudit(ProgramLogExerciseAudit audit);
    }
}
