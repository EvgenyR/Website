using System;
using System.Text;

namespace HtmlHelpers
{
    public static class DateTimeExtensionMethods
    {
        public static string ToW3CDate(this DateTime dt)
        {
            return dt.ToUniversalTime().ToString("s") + "Z";
        }

        /// <summary>
        /// Returns a nicely formatted duration
        /// eg. 3 seconds ago, 4 hours ago etc.
        /// </summary>
        /// <param name="dateTime">The datetime value</param>
        /// <returns>A nicely formatted duration</returns>
        /// <see cref="http://samscode.com/index.php/2009/12/timespan-or-datetime-to-friendly-duration-text-e-g-3-days-ago/"/>
        public static string TimeAgoString(this DateTime dateTime)
        {
            StringBuilder sb = new StringBuilder();
            TimeSpan timespan = DateTime.Now - dateTime;

            // A year or more?  Do "[Y] years and [M] months ago"
            if ((int)timespan.TotalDays >= 365)
            {
                // Years
                int nYears = (int)timespan.TotalDays / 365;
                sb.Append(nYears);
                if (nYears > 1)
                    sb.Append(" years");
                else
                    sb.Append(" year");

                // Months
                int remainingDays = (int)timespan.TotalDays - (nYears * 365);
                int nMonths = remainingDays / 30;
                if (nMonths == 1)
                    sb.Append(" and ").Append(nMonths).Append(" month");
                else if (nMonths > 1)
                    sb.Append(" and ").Append(nMonths).Append(" months");
            }
            // More than 60 days? (appx 2 months or 8 weeks)
            else if ((int)timespan.TotalDays >= 60)
            {
                // Do months
                int nMonths = (int)timespan.TotalDays / 30;
                sb.Append(nMonths).Append(" months");
            }
            // Weeks? (7 days or more)
            else if ((int)timespan.TotalDays >= 7)
            {
                int nWeeks = (int)timespan.TotalDays / 7;
                sb.Append(nWeeks);
                if (nWeeks == 1)
                    sb.Append(" week");
                else
                    sb.Append(" weeks");
            }
            // Days? (1 or more)
            else if ((int)timespan.TotalDays >= 1)
            {
                int nDays = (int)timespan.TotalDays;
                sb.Append(nDays);
                if (nDays == 1)
                    sb.Append(" day");
                else
                    sb.Append(" days");
            }
            // Hours?
            else if ((int)timespan.TotalHours >= 1)
            {
                int nHours = (int)timespan.TotalHours;
                sb.Append(nHours);
                if (nHours == 1)
                    sb.Append(" hour");
                else
                    sb.Append(" hours");
            }
            // Minutes?
            else if ((int)timespan.TotalMinutes >= 1)
            {
                int nMinutes = (int)timespan.TotalMinutes;
                sb.Append(nMinutes);
                if (nMinutes == 1)
                    sb.Append(" minute");
                else
                    sb.Append(" minutes");
            }
            // Seconds?
            else if ((int)timespan.TotalSeconds >= 1)
            {
                int nSeconds = (int)timespan.TotalSeconds;
                sb.Append(nSeconds);
                if (nSeconds == 1)
                    sb.Append(" second");
                else
                    sb.Append(" seconds");
            }
            // Just say "1 second" as the smallest unit of time
            else
            {
                sb.Append("1 second");
            }

            sb.Append(" ago");

            // For anything more than 6 months back, put " ([Month] [Year])" at the end, for better reference
            if ((int)timespan.TotalDays >= 30 * 6)
            {
                sb.Append(" (" + dateTime.ToString("MMMM") + " " + dateTime.Year + ")");
            }

            return sb.ToString();
        }
    }
}