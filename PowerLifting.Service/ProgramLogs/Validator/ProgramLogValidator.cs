using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Exceptions;
using PowerLifting.Service.TemplatePrograms.Exceptions;

namespace PowerLifting.Service.ProgramLogs.Validator
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

        public void ValiateUserHasLiftingStatSetForTemplateExercises(IEnumerable<LiftingStat> liftingStat)
        {
            if(liftingStat == null || !liftingStat.Any())
            {
                throw new TemplateExercise1RMNotSetForUserException();
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
