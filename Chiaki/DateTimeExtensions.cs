using System;

namespace Chiaki
{
    /// <summary>
    /// Provides extensions for System.DateTime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the DateTime into UNIX Timestamp format
        /// </summary>
        public static double ToUnixTimestamp(this DateTime input)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = input - origin;

            return Math.Floor(diff.TotalSeconds);
        }

        /// <summary>
        /// Gets the date of the start of week
        /// </summary>
        public static DateTime GetStartOfWeek(this DateTime input, DayOfWeek startOfWeek)
        {
            int diff = input.DayOfWeek - startOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return input.AddDays(-1 * diff).Date;
        }
    }
}