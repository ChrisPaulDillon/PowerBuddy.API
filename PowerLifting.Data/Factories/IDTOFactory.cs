using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Data.Factories
{
    public interface IDTOFactory
    {
        public ProgramLogRepSchemeDTO CreateRepScheme(int setNo, int noOfReps, decimal weightLifted);
    }
}
