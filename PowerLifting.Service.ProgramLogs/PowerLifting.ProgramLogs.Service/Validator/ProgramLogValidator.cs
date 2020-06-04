using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.ProgramLogs.Service.Exceptions;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Exceptions;

namespace PowerLifting.ProgramLogs.Service.Validator
{
    public class ProgramLogValidator
    {
        public ProgramLogValidator()
        {

        }

        public void ValidateProgramLogId(int programLogId)
        {
            if (programLogId < 1)
            {
                throw new ProgramLogValidationException("ProgramLogId cannot be negative");
            }
        }

        public void ValidateProgramLogDaysMatchTemplateDaysCount(int programDayCount, int templateDayCount)
        {
            if(programDayCount != templateDayCount)
            {
                throw new ProgramDaysDoesNotMatchTemplateDaysException();
            }
        }

        #region ProgramLogWeekValidation

        public void ValidateProgramLogWeekId(int programLogWeekId)
        {
            if (programLogWeekId < 1)
            {
                throw new ProgramLogValidationException("The following ProgramLogWeekId must be greater than zero: " + programLogWeekId);
            }
        }

        #endregion

        #region ProgramLogDayValidation

        public void ValidateProgramLogDayId(int programLogDayId)
        {
            if (programLogDayId < 1)
            {
                throw new ProgramLogValidationException("The following ProgramLogDayId must be greater than zero: " + programLogDayId);
            }
        }

        public void ValidateProgramLogDayWithinProgramLogWeek(DateTime startWeek, DateTime endWeek, DateTime dateSelected)
        {
            if(dateSelected >= startWeek && dateSelected < endWeek)
            {
                return;
            }
            throw new ProgramLogDayNotWithWeekRangeException();
        }

        #endregion

        #region ProgramExercisesValidation

        public void ValidateProgramLogExerciseId(int programLogExerciseId)
        {
            if (programLogExerciseId < 1)
            {
                throw new ProgramLogValidationException("The supplied parameter of 'programLogExerciseId' must be greater than zero: " + programLogExerciseId);
            }
        }

        #endregion

        #region ProgramLogRepSchemesValidaton

        public void ValidateProgramLogRepSchemeId(int programLogRepSchemeId)
        {
            if (programLogRepSchemeId < 1)
            {
                throw new ProgramLogValidationException("The supplied parameter of 'programLogRepSchemeId' must be greater than zero: " + programLogRepSchemeId);
            }
        }

        #endregion

    }
}
