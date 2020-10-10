﻿using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.EntityFactories
{
    public class TonnageFactory : ITonnageFactory
    {
        public TonnageDayExercise CreateDay(int programLogId, int programLogDayId, int exerciseId, decimal dayTonnage, string userId)
        {
            return new TonnageDayExercise()
            {
                ProgramLogId = programLogId,
                ProgramLogDayId = programLogDayId,
                ExerciseId = exerciseId,
                DayTonnage = dayTonnage,
                UserId = userId
            };
        }
    }
}
