using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramDaysDoesNotMatchTemplateDaysException : Exception
    {
        public ProgramDaysDoesNotMatchTemplateDaysException() : base("The number of days supplied does not match the number of days associated with this template program")
        {
        }
    }
}
