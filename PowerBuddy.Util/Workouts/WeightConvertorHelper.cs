using System;
using System.Collections;

namespace PowerBuddy.Util.Workouts
{
    public static class WeightConvertorHelper
    {
        private const decimal POUNDS_TO_KILOGRAM = 0.45359237M;
        private const decimal KILOGRAM_TO_POUNDS = 2.20462262185M;

        public static decimal RoundWeightToNearestQuarter(decimal weight)
        {
            return Math.Round(weight * 4, MidpointRounding.ToEven) / 4;
        }

        public static decimal ConvertWeightToPounds(decimal weight)
        {
            return RoundWeightToNearestQuarter(weight * KILOGRAM_TO_POUNDS);
        }

        /// <summary>
        /// Only used for returned weights, not db inserts
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static decimal ConvertWeightToKg(decimal weight)
        {
            return RoundWeightToNearestQuarter(weight * POUNDS_TO_KILOGRAM);
        }
    }
}
