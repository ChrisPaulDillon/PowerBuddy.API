using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Tonnage;

namespace PowerLifting.Data.EntityFactories
{
    public class TonnageFactory : ITonnageFactory
    {
        public TonnageDay CreateDay(int programLogId, int programLogDayId, int exerciseId, decimal dayTonnage, string userId)
        {
            return new TonnageDay()
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
