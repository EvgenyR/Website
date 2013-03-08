using System;

namespace Recipes.HtmlHelpers
{
    /// <summary>
    /// A utility class to keep track of a start and an end date
    /// </summary>
    public class TimePeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TimePeriod()
        {
            Start = DateHelper.SqlMinDate;
            End = DateHelper.SqlMaxDate;
        }
    }

    /// <summary>
    /// This helper class provides a quick way to get common time periods like 'Today', 'Yesterday'
    /// </summary>
    public static class TimePeriodHelper
    {

        /// <summary>
        /// This methods provides a quick way to get a Time Period in Universal Time
        /// </summary>
        /// <param name="period">The string based name of a period. Eg. Today, Tomorrow</param>
        /// <returns>A time period</returns>
        public static TimePeriod GetUtcTimePeriod(string period)
        {
            TimePeriod timePeriod = GetTimePeriod(period);

            timePeriod.Start = timePeriod.Start.ToUniversalTime();
            timePeriod.End = timePeriod.End.ToUniversalTime();

            return timePeriod;
        }

        /// <summary>
        /// This methods provides a quick way to get a Time Period
        /// </summary>
        /// <param name="period">The string based name of a period. Eg. Today, Tomorrow</param>
        /// <returns>A time period</returns>
        public static TimePeriod GetTimePeriod(string period)
        {
            TimePeriod timePeriod = new TimePeriod();

            switch (period)
            {
                case "Today":
                    timePeriod.Start = DateTime.Now.Date;
                    timePeriod.End = timePeriod.Start.Add(new TimeSpan(23, 59, 59));
                    break;

                case "Yesterday":
                    timePeriod.Start = DateTime.Now.Date.AddDays(-1);
                    timePeriod.End = timePeriod.Start.Add(new TimeSpan(23, 59, 59));
                    break;

                case "This Week":
                    timePeriod.Start = DateHelper.GetStartOfCurrentWeek();
                    timePeriod.End = DateHelper.GetEndOfCurrentWeek().Add(new TimeSpan(23, 59, 59));
                    break;

                case "Last Week":
                    timePeriod.Start = DateHelper.GetStartOfLastWeek();
                    timePeriod.End = DateHelper.GetEndOfLastWeek().Add(new TimeSpan(23, 59, 59));
                    break;

                case "This Month":
                    timePeriod.Start = DateHelper.GetStartOfCurrentMonth();
                    timePeriod.End = DateHelper.GetEndOfCurrentMonth().Add(new TimeSpan(23, 59, 59));
                    break;

                case "Last Month":
                    timePeriod.Start = DateHelper.GetStartOfLastMonth();
                    timePeriod.End = DateHelper.GetEndOfLastMonth().Add(new TimeSpan(23, 59, 59));
                    break;

                case "Last 30 days":
                    timePeriod.Start = DateTime.Now.Date.AddDays(-30);
                    timePeriod.End = DateTime.Now.Date;
                    break;

                case "Last 60 days":
                    timePeriod.Start = DateTime.Now.Date.AddDays(-60);
                    timePeriod.End = DateTime.Now.Date;
                    break;

                case "Last 90 days":
                    timePeriod.Start = DateTime.Now.Date.AddDays(-90);
                    timePeriod.End = DateTime.Now.Date;
                    break;

                default: // All
                    timePeriod.Start = new DateTime(1980, 1, 1);
                    timePeriod.End = DateHelper.GetEndOfCurrentYear();
                    break;
            }

            return timePeriod;
        }
    }
}