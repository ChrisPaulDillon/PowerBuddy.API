using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Systems.Service.Exceptions
{
    public class ExerciseNotFoundException : Exception
    {
        public ExerciseNotFoundException() : base("Exercise Not Found")
        {

        }
    }
}