using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Service.Tonnages
{
    public static class TonnageHelper
    {
        public static decimal CalculateTonnage(decimal weight, int reps)
        {
            return weight * reps;
        }

    }
}
