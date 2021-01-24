using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class WorkoutDaysDoesNotMatchTemplateDaysException : Exception
    {
        public WorkoutDaysDoesNotMatchTemplateDaysException() : base("The number of days supplied does not match the number of days associated with this template program")
        {
        }
    }
}
