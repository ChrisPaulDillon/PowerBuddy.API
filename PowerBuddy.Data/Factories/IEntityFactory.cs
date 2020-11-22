﻿using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Factories
{
    public interface IEntityFactory
    {
        public LiftingStatAudit CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int programLogRepSchemeId, string userId);

        //ProgramLogs
        public ProgramLogRepScheme CreateRepScheme(int programLogExerciseId, int setNo, int noOfReps, decimal weightLifted);
        public ProgramLogWeek CreateProgramLogWeek(DateTime startDate, int weekNo, string userId);
        public ProgramLogWeek CreateProgramLogWeekWithDays(DateTime startDate, int weekNo, string userId);
        public ProgramLogDay CreateProgramLogDay(DateTime date, string userId);
        public ProgramLogExercise CreateProgramLogExercise(int noOfSets, int exerciseId);

        public ProgramLogRepScheme CreateProgramLogRepScheme(int setNo, int noOfReps, decimal percentage, decimal weightLifted, bool amrap);
        public ProgramLogExerciseTonnage CreateProgramLogExerciseTonnage(int programLogExerciseId, decimal exerciseTonnage, string userId, int exerciseId);
    }
}