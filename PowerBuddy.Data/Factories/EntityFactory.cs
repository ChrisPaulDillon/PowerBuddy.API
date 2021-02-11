using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Factories
{
    public class EntityFactory : IEntityFactory
    {
        public LiftingStatAudit CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, string userId)
        {
            return new LiftingStatAudit()
            {
                RepRange = repRange,
                ExerciseId = exerciseId,
                Weight = weight,
                DateChanged = date,
                UserId = userId,
            };
        }
        public TemplateProgramAudit CreateTemplateProgramAudit(int templateProgramId, string userId, DateTime dateAdded)
        {
            return new TemplateProgramAudit()
            {
                TemplateProgramId = templateProgramId,
                UserId = userId,
                DateCreated = dateAdded
            };
        }

        public WorkoutDay CreateWorkoutDay(int weekNo, DateTime date, string userId)
        {
            return new WorkoutDay()
            {
                WeekNo = weekNo,
                Date = date,
                UserId = userId
            };
        }


        public WorkoutDay CreateWorkoutDayWithProgram(int weekNo, DateTime date, int workoutLogId, string userId)
        {
            return new WorkoutDay()
            {
                WeekNo = weekNo,
                Date = date,
                UserId = userId,
                WorkoutLogId = workoutLogId
            };
        }

        public WorkoutExercise CreateWorkoutExercise(int exerciseId)
        {
            return new WorkoutExercise()
            {
                ExerciseId = exerciseId,
                WorkoutSets = new List<WorkoutSet>()
            };
        }

        public WorkoutExerciseTonnage CreateWorkoutExerciseTonnage(decimal exerciseTonnage, int exerciseId, string userId)
        {
            return new WorkoutExerciseTonnage()
            {
                ExerciseTonnage = exerciseTonnage,
                ExerciseId = exerciseId,
                UserId = userId,
            };
        }

        public WorkoutSet CreateWorkoutSet(int noOfReps, decimal weightLifted, bool amrap)
        {
            return new WorkoutSet()
            {
                NoOfReps = noOfReps,
                WeightLifted = weightLifted,
                AMRAP = amrap
            };
        }

        public WorkoutSet CreateWorkoutSet(int workoutExerciseId, int noOfReps, decimal weightLifted, bool amrap)
        {
            return new WorkoutSet()
            {
                WorkoutExerciseId = workoutExerciseId,
                NoOfReps = noOfReps,
                WeightLifted = weightLifted,
                AMRAP = amrap
            };
        }

        public RefreshToken CreateRefreshToken(string jwtId, string userId)
        {
            return new RefreshToken()
            {
                Token = Guid.NewGuid().ToString(),
                JwtId = jwtId,
                UserId = userId,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };
        }
    }
}
