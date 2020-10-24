﻿using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Service.ProgramLogs.Factories
{
    public static class ProgramLogFactory
    {
        public static CProgramLogWeekDTO CreateProgramLogWeek(DateTime startDate, int weekNo, string userId)
        {
            return new CProgramLogWeekDTO()
            {
                StartDate = startDate,
                EndDate = startDate.AddDays(7),
                WeekNo = weekNo,
                UserId = userId,
                ProgramLogDays = new List<CProgramLogDayDTO>()
            };
        }

        public static CProgramLogExerciseDTO CreateProgramLogExercise(int noOfSets, int exerciseId)
        {
            return new CProgramLogExerciseDTO()
            {
                ExerciseId = exerciseId,
                NoOfSets = noOfSets,
                ProgramLogRepSchemes = new List<ProgramLogRepSchemeDTO>()
            };
        }

        public static ProgramLogRepSchemeDTO CreateProgramLogRepScheme(int setNo, int noOfReps, decimal percentage, decimal weightLifted, bool amrap)
        {
            return new ProgramLogRepSchemeDTO()
            {
                SetNo = setNo,
                NoOfReps = noOfReps,
                Percentage = percentage,
                WeightLifted = weightLifted,
                AMRAP = amrap,
            };
        }
    }
}
