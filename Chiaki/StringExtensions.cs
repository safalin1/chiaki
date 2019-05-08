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
        /// Prepends <paramref name="prepend"/> to the string if it does not start with <paramref name="prepend"/>
        /// </summary>
        public static string PrependIfNeeded(this string input, string prepend)
        {
            if (input == null)
            {
                return input;
            }

            if (input.StartsWith(prepend))
            {
                return input;
            }

            return prepend + input.TrimStart(prepend);
        }

        /// <summary>
        /// Prepends <paramref name="prepend"/> if the string does not start with <paramref name="prepend"/>
        /// </summary>
        public static string PrependIfNeeded(this string input, char prepend)
        {
            if (input == null)
            {
                return input;
            }

            return input.StartsWith(prepend.ToString(CultureInfo.InvariantCulture))
                ? input
                : prepend + input;
        }

        /// <summary>
        /// Appends <paramref name="append"/> to the string if it does not end with <paramref name="append"/>
        /// </summary>
        public static string AppendIfNeeded(this string input, char append)
        {
            if (input == null)
            {
                return input;
            }

            return input.EndsWith(append.ToString(CultureInfo.InvariantCulture)) ? input : input + append;
        }

        /// <summary>
        /// Appends <paramref name="append"/> to the string if it does not end with <paramref name="append"/>
        /// </summary>
        public static string AppendIfNeeded(this string input, string append)
        {
            if (input == null)
            {
                return input;
            }

            return input.EndsWith(append.ToString(CultureInfo.InvariantCulture)) ? input : input + append;
        }

        /// <summary>
        /// Trims <paramref name="remove"/> from the end of the string.
        /// </summary>
        public static string TrimEnd(this string input, string remove)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (string.IsNullOrEmpty(remove))
            {
                return input;
            }

            while (input.EndsWith(remove, StringComparison.InvariantCultureIgnoreCase))
            {
                input = input.Remove(input.LastIndexOf(remove, StringComparison.InvariantCultureIgnoreCase));
            }

            return input;
        }

        /// <summary>
        /// Trims <paramref name="remove"/> from the start of the string.
        /// </summary>
        public static string TrimStart(this string input, string remove)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (string.IsNullOrEmpty(remove))
            {
                return input;
            }

            while (input.StartsWith(remove, StringComparison.InvariantCultureIgnoreCase))
            {
                input = input.Substring(remove.Length);
            }

            return input;
        }
    }
}