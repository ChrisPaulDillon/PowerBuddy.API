using System;
using System.Collections.Generic;
using System.Globalization;

namespace PowerLifting.Repository.Util
{
    public sealed class DateHelper
    {
        private static readonly DateHelper instance = new DateHelper();

        static DateHelper()
        {

        }

        private DateHelper()
        {

        }

        public static DateHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }

        public List<DateTime> GetWeekRangeOfCurrentWeek()
        {
            // 46
            int thisWeekNumber = GetIso8601WeekOfYear(DateTime.Today);
            DateTime firstDayOfWeek = FirstDateOfWeek(2020, thisWeekNumber, CultureInfo.CurrentCulture);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(7);
            List<DateTime> dateRangeOfCurrentWeek = new List<DateTime>();
            dateRangeOfCurrentWeek.Add(firstDayOfWeek);
            dateRangeOfCurrentWeek.Add(lastDayOfWeek);
            return dateRangeOfCurrentWeek;
            //DateTime firstDayOfLastYearWeek = FirstDateOfWeek(2020, thisWeekNumber, CultureInfo.CurrentCulture);
        }
    }
}
