using System;

namespace Chiaki
{
    /// <summary>
    /// Provides extensions for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a DateTime into UNIX Timestamp format
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

        /// <summary>
        /// Gets the age of a DateTime.
        /// </summary>
        /// <param name="input">The datetime to calculate the age for.</param>
        public static int GetAge(this DateTime input)
        {
            return input.GetAge(calculateAgainst: DateTime.Today);
        }


        /// <summary>
        /// Gets the age of a DateTime, using another provided DateTime to calculate against.
        /// </summary>
        /// <param name="input">The datetime to calculate the age for.</param>
        /// <param name="calculateAgainst">A datetime to calculate the age against</param>
        public static int GetAge(this DateTime input, DateTime calculateAgainst)
        {
            DateTime now = calculateAgainst;

            int age = now.Year - input.Year;

            if (input > now.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}