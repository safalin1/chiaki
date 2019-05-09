using System;
using System.Globalization;
// ReSharper disable UnusedMember.Global

namespace Chiaki
{
    /// <summary>
    /// Provides extensions for System.String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Prepends <paramref name="value"/> to the string if it does not start with <paramref name="value"/>
        /// </summary>
        public static string PrependIfNeeded(this string input, string value)
        {
            if (input == null)
            {
                return input;
            }

            if (input.StartsWith(value))
            {
                return input;
            }

            return value + input.TrimStart(value);
        }

        /// <summary>
        /// Prepends <paramref name="value"/> if the string does not start with <paramref name="value"/>
        /// </summary>
        public static string PrependIfNeeded(this string input, char value)
        {
            if (input == null)
            {
                return input;
            }

            return input.StartsWith(value.ToString(CultureInfo.InvariantCulture))
                ? input
                : value + input;
        }

        /// <summary>
        /// Appends <paramref name="value"/> to the string if it does not end with <paramref name="value"/>
        /// </summary>
        public static string AppendIfNeeded(this string input, char value)
        {
            if (input == null)
            {
                return input;
            }

            return input.EndsWith(value.ToString(CultureInfo.InvariantCulture)) ? input : input + value;
        }

        /// <summary>
        /// Appends <paramref name="value"/> to the string if it does not end with <paramref name="value"/>
        /// </summary>
        public static string AppendIfNeeded(this string input, string value)
        {
            if (input == null)
            {
                return input;
            }

            return input.EndsWith(value.ToString(CultureInfo.InvariantCulture)) ? input : input + value;
        }

        /// <summary>
        /// Trims <paramref name="value"/> from the end of the string.
        /// </summary>
        public static string TrimEnd(this string input, string value)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (string.IsNullOrEmpty(value))
            {
                return input;
            }

            while (input.EndsWith(value, StringComparison.InvariantCultureIgnoreCase))
            {
                input = input.Remove(input.LastIndexOf(value, StringComparison.InvariantCultureIgnoreCase));
            }

            return input;
        }

        /// <summary>
        /// Trims <paramref name="value"/> from the start of the string.
        /// </summary>
        public static string TrimStart(this string input, string value)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (string.IsNullOrEmpty(value))
            {
                return input;
            }

            while (input.StartsWith(value, StringComparison.InvariantCultureIgnoreCase))
            {
                input = input.Substring(value.Length);
            }

            return input;
        }
    }
}