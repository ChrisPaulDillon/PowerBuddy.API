using System;

namespace PowerBuddy.Util.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - endOfWeek)) % 7;
            return dt.AddDays((-1 * diff) + 7).Date;
        }

        public static DateTime ClosestDateByDay(this DateTime dt, DayOfWeek day)
        {
            var daysUntilSpecificDay = ((int)day - (int)dt.DayOfWeek + 7) % 7;
            return dt.AddDays(daysUntilSpecificDay);
        }
    }
}