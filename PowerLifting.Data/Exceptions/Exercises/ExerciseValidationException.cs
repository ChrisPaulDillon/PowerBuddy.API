using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Exceptions.Exercises
{
    public class ExerciseValidationException : Exception
    {
        public ExerciseValidationException(string message) : base(message) { }

        public ExerciseValidationException() : base("Exercise could not be found with the supplied parameters") { }
    }
}
