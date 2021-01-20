using System;

namespace PowerBuddy.Util.Workouts
{
    public static class WeightConvertorHelper
    {
        public static decimal RoundWeight(decimal weight)
        {
            return Math.Round((decimal)(weight * 2), MidpointRounding.AwayFromZero) / 2;
        }

        public static decimal ConvertWeightToPounds(decimal weight)
        {
            return RoundWeight(weight * 2.2M);
        }

        public static decimal CalculateWeight(bool isMetric, decimal weight)
        {
            if (isMetric)
            {
                return RoundWeight(weight);
            }
            else
            {
                return ConvertWeightToPounds(weight);
            }
        }
    }
}
