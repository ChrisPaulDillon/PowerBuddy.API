using PowerLifting.Service.LiftingStats.Exceptions;

namespace PowerLifting.Service.LiftingStats.Validators
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
