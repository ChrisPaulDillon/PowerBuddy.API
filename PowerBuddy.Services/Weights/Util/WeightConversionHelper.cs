using System;
using PowerBuddy.Services.Weights.Util;

namespace PowerBuddy.WeightHelper
{
    public static class WeightConversionHelper
    {
        public static decimal RoundWeightToNearestQuarter(decimal weight)
        {
            return Math.Round(weight * 4, MidpointRounding.ToEven) / 4;
        }

        public static decimal ConvertWeightToPounds(decimal weight)
        {
            return RoundWeightToNearestQuarter(weight * WeightConstants.KILOGRAM_TO_POUNDS);
        }

        /// <summary>
        /// Only used for returned weights, not db inserts
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static decimal ConvertWeightToKg(decimal weight)
        {
            return RoundWeightToNearestQuarter(weight * WeightConstants.POUNDS_TO_KILOGRAM);
        }
    }
}
