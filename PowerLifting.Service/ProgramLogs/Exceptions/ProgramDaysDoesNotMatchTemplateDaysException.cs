using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramDaysDoesNotMatchTemplateDaysException : Exception
    {
        public ProgramDaysDoesNotMatchTemplateDaysException() : base("The number of days supplied does not match the number of days associated with this template program")
        {
        }
    }
}
