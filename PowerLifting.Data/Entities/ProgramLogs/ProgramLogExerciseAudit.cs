using System;
namespace PowerLifting.Entity.ProgramLogs.Model
{
    /// <summary>
    /// Used to log how many times an exercise is selected by a user
    /// </summary>
    public class ProgramLogExerciseAudit
    {
        public int ProgramLogExerciseAuditId { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public int ExerciseTypeId { get; set; }
        public int SelectedCount { get; set; }
    }
}
