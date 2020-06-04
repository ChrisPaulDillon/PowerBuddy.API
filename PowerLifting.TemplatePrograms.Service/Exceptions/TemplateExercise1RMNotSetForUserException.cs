using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Service.TemplatePrograms.Exceptions
{
    public class TemplateExercise1RMNotSetForUserException : Exception
    {
        public TemplateExercise1RMNotSetForUserException() : base(
            "User does not have an exercise 1RM set for a lift on this template")
        {

        }
    }
}
