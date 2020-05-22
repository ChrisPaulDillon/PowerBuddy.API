using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Exceptions;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.TemplatePrograms.Exceptions;
using PowerLifting.Service.TemplatePrograms.Model;

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
                throw new ProgramLogValidationException("ProgramLogWeekId cannot be null");
            }
        }

        public void ValidateProgramLogWeekExists(ProgramLogWeek programWeek)
        {
            if (programWeek == null)
            {
                throw new ProgramLogWeekDoesNotExistException();
            }
        }

        #endregion

        #region ProgramLogDayValidation

        public void ValidateProgramLogDayId(int programLogDayId)
        {
            if (programLogDayId < 1)
            {
                throw new ProgramLogDayDoesNotExistException();
            }
        }

        public void ValidateProgramLogDayExists(ProgramLogDay programDay)
        {
            if (programDay == null)
            {
                throw new ProgramLogDayDoesNotExistException();
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
                throw new ProgramLogExerciseNotFoundException();
            }
        }

        public void ValidateProgramExerciseExists(ProgramLogExercise programExercise)
        {
            if(programExercise == null)
            {
                throw new ProgramLogExerciseNotFoundException();
            }
        }

        #endregion

        #region ProgramLogRepSchemesValidaton

        public void ValidateProgramLogRepSchemeId(int programLogRepSchemeId)
        {
            if (programLogRepSchemeId < 1)
            {
                throw new ProgramLogRepSchemeDoesNotExistException();
            }
        }

        public void ValidateProgramRepSchemeExists(ProgramLogRepScheme programLogRepScheme)
        {
            if (programLogRepScheme == null)
            {
                throw new ProgramLogExerciseNotFoundException();
            }
        }

        #endregion

    }
}
