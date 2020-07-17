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

        /// <summary>
        /// Gets the first day of the week.
        /// </summary>
        /// <param name="input">The datetime to get the first day of the week for.</param>
        /// <returns>A DateTime representing the first day of the week</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime input)
        {
            return new DateTime(input.Year, input.Month, input.Day).AddDays(-(int)input.DayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the week.
        /// </summary>
        /// <param name="input">The datetime to get the last day of the week for.</param>
        /// <returns>A DateTime representing the last day of the week</returns>
        public static DateTime GetLastDayOfWeek(this DateTime input)
        {
            return new DateTime(input.Year, input.Month, input.Day).AddDays(6 - (int)input.DayOfWeek);
        }

        /// <summary>
        /// Returns true if the time is in the morning
        /// </summary>
        public static bool IsMorning(this DateTime input)
        {
            return input.TimeOfDay < TimeSpan.Parse("12:00:00");
        }

        /// <summary>
        /// Returns true if the time is in the afternoon. 
        /// </summary>
        public static bool IsAfternoon(this DateTime input)
        {
            return input.TimeOfDay >= TimeSpan.Parse("12:00:00");
        }

        /// <summary>
        /// Returns true if the date is today.
        /// </summary>
        public static bool IsToday(this DateTime input)
        {
            return input.Date == DateTime.Today;
        }

        /// <summary>
        /// Returns true if the datetime is in the past.
        /// </summary>
        public static bool IsPast(this DateTime input)
        {
            return input < DateTime.Now;
        }

        /// <summary>
        /// Returns true if the datetime is in the past (using UTC time).
        /// </summary>
        public static bool IsPastUtc(this DateTime input)
        {
            return input < DateTime.UtcNow;
        }

        /// <summary>
        /// Returns true if the datetime is in the future.
        /// </summary>
        public static bool IsFuture(this DateTime input)
        {
            return input > DateTime.Now;
        }

        /// <summary>
        /// Returns true if the datetime is in the future (using UTC time).
        /// </summary>
        public static bool IsFutureUtc(this DateTime input)
        {
            return input > DateTime.UtcNow;
        }

        /// <summary>
        /// Adds 1 day onto the provided date. The time is preserved.
        /// </summary>
        /// <returns>A datetime with the same time as the input but one day into the future.</returns>
        public static DateTime Tomorrow(this DateTime input)
        {
            return input.AddDays(1);
        }

        /// <summary>
        /// Subtracts 1 day from the provided date. The time is preserved.
        /// </summary>
        /// <returns>A datetime with the same time as the input but one day into the future.</returns>
        public static DateTime Yesterday(this DateTime input)
        {
            return input.AddDays(-1);
        }

        /// <summary>
        /// Returns true if the datetime provided falls on a Saturday or Sunday.
        /// </summary>
        public static bool IsWeekend(this DateTime input)
        {
            return input.DayOfWeek == DayOfWeek.Saturday || input.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}