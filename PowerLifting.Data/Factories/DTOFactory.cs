using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Data.Factories
{
    public class DTOFactory : IDTOFactory
    {
        public ProgramLogRepSchemeDTO CreateRepScheme(int setNo, int noOfReps, decimal weightLifted)
        {
            return new ProgramLogRepSchemeDTO()
            {
                SetNo = setNo,
                NoOfReps = noOfReps,
                WeightLifted = weightLifted
            };
        }
    }
}
