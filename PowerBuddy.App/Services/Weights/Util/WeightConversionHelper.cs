using System;

namespace PowerBuddy.App.Services.Weights.Util
{
    public static class WeightConversionHelper
    {
        private static decimal RoundWeightToNearestQuarter(decimal weight)
        {
            return Math.Round(weight * 4, MidpointRounding.ToEven) / 4;
        }

        /// <summary>
        /// Converts weight to kilograms for db insert
        /// </summary>
        public static decimal ConvertWeightToKiloInsert(decimal weight)
        {
            return weight * WeightConstants.POUNDS_TO_KILOGRAM;
        }

        /// <summary>
        /// Converts weight to pounds to be displayed to the user
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static decimal ConvertWeightToPoundsOutgoing(decimal weight)
        {
            return RoundWeightToNearestQuarter(weight * WeightConstants.KILOGRAM_TO_POUNDS);
        }

        /// <summary>
        /// Converts weight to pounds to be displayed to the user
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static decimal ConvertWeightToKiloOutgoing(decimal weight)
        {
            return RoundWeightToNearestQuarter(weight);
        }

    }
}
