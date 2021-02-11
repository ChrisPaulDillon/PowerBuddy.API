using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Factories
{
    public interface IEntityFactory
    {
        public LiftingStatAudit CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, string userId);
        public TemplateProgramAudit CreateTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded);

        //Workouts

        public WorkoutDay CreateWorkoutDay(int weekNo, DateTime date, string userId);
        public WorkoutDay CreateWorkoutDayWithProgram(int weekNo, DateTime date, int workoutLogId, string userId);
        public WorkoutExercise CreateWorkoutExercise(int exerciseId);
        public WorkoutExerciseTonnage CreateWorkoutExerciseTonnage(decimal exerciseTonnage, int exerciseId, string userId);
        public WorkoutSet CreateWorkoutSet(int noOfReps, decimal weightLifted, bool amrap);
        public WorkoutSet CreateWorkoutSet(int workoutExerciseId, int noOfReps, decimal weightLifted, bool amrap);

        public RefreshToken CreateRefreshToken(string jwtId, string userId);
    }
}
