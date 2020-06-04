using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Systems.Service.Exceptions
{
    public class ExerciseTypeNotFoundException : Exception
    {
        public ExerciseTypeNotFoundException() : base("ExerciseType Not Found")
        {

        }
    }
}
