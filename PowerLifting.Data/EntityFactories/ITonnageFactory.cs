using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.EntityFactories
{
    public interface ITonnageFactory
    {
        public TonnageDay CreateDay(int programLogId, int programLogDayId, int exerciseId, decimal dayTonnage, string userId);
    }
}
