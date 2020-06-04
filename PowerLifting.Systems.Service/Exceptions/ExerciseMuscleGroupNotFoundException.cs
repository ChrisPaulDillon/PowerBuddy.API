using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Systems.Service.Exceptions
{
    public class ExerciseMuscleGroupNotFoundException : Exception
    {
        public ExerciseMuscleGroupNotFoundException() : base("ExerciseMuscleGroup Not Found")
        {

        }
    }
}