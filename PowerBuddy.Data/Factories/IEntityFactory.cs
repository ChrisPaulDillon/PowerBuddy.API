using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Factories
{
    public interface IEntityFactory
    {
        public LiftingStatAudit CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, string userId);

        //ProgramLogs
        public ProgramLogRepScheme CreateRepScheme(int programLogExerciseId, int setNo, int noOfReps, decimal weightLifted);
        public ProgramLogWeek CreateProgramLogWeek(DateTime startDate, int weekNo, string userId);
        public ProgramLogWeek CreateProgramLogWeekWithDays(DateTime startDate, int weekNo, string userId);
        public ProgramLogDay CreateProgramLogDay(DateTime date, string userId);
        public ProgramLogExercise CreateProgramLogExercise(int noOfSets, int exerciseId);

        public ProgramLogRepScheme CreateProgramLogRepScheme(int setNo, int noOfReps, decimal percentage, decimal weightLifted, bool amrap);
        public ProgramLogExerciseTonnage CreateProgramLogExerciseTonnage(int programLogExerciseId, decimal exerciseTonnage, string userId, int exerciseId);

        public TemplateProgramAudit CreateTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded);

        //Workouts

        public WorkoutDay CreateWorkoutDay(int weekNo, DateTime date, string userId);
        public WorkoutExercise CreateWorkoutExercise(int exerciseId);
        public WorkoutExerciseTonnage CreateWorkoutExerciseTonnage(decimal exerciseTonnage, int exerciseId, string userId);
        public WorkoutSet CreateWorkoutSet(int noOfReps, decimal weightLifted, bool amrap);
        public WorkoutSet CreateWorkoutSet(int workoutExerciseId, int noOfReps, decimal weightLifted, bool amrap);
    }
}
