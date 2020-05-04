using System;
using PowerLifting.Service.LiftingStats.Exceptions;
using PowerLifting.Service.LiftingStats.Model;

namespace PowerLifting.Service.LiftingStats.Validators
{
    public class LiftingStatValidator
    {
        public LiftingStatValidator()
        {
        }

        public void ValidateLiftingStatDoesNotAlreadyExist(LiftingStat liftingStat)
        {
            if(liftingStat != null)
            {
                throw new LiftingStatRepRangeAlreadyExistsException();
            }
        }

        public void ValidateLiftingStatExists(LiftingStat liftingStat)
        {
            if (liftingStat == null)
            {
                throw new LiftingStatNotFoundException("Lifting stat not found");
            }
        }
    }
}
