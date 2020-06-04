using PowerLifting.LiftingStats.Service.Exceptions;

namespace PowerLifting.LiftingStats.Service.Validator 
{
    public class LiftingStatValidator
    {
        public LiftingStatValidator()
        {
        }

        public void ValidateLiftingStatId(int liftingStatId)
        {
            if (liftingStatId < 1)
            {
                throw new LiftingStatNotFoundException();
            }
        }
    }
}
