using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

// ReSharper disable UnusedMember.Global

namespace Chiaki
{
    /// <summary>
    /// Provides extensions for <see cref="string"/>
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

        /// <summary>
        /// Strips whitespace, tabs, carriage returns, new line, vertical tab and form feed characters from a string.
        /// </summary>
        /// <remarks>
        /// This method uses Regex \s to match.
        /// </remarks>
        internal static string StripWhitespace(this string input)
        {
            return Regex.Replace(input, @"\s", string.Empty);
        }

        /// <summary>
        /// Strips all HTML tags from a string.
        /// </summary>
        public static string StripHtml(this string input)
        {
            const string pattern = @"<(.|\n)*?>";

            return Regex.Replace(input, pattern, string.Empty, RegexOptions.Compiled);
        }

        /// <summary>
        /// Strips all carriage returns from a string.
        /// </summary>
        public static string StripNewLines(this string input)
        {
            return input
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty);
        }

        /// <summary>
        /// Converts a string to hexadecimal format.
        /// </summary>
        public static string ToHexadecimal(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var builder = new StringBuilder(input.Length);

            foreach (var c in input)
            {
                builder.AppendFormat("{0:x2}", Convert.ToUInt32(c));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts a string from hexadecimal format.
        /// </summary>
        public static string FromHexadecimal(this string hexadecimal)
        {
            var builder = new StringBuilder();

            while (hexadecimal.Length > 0)
            {
                builder.Append(Convert.ToChar(Convert.ToUInt32(hexadecimal.Substring(0, 2), 16)).ToString());
                hexadecimal = hexadecimal.Substring(2, hexadecimal.Length - 2);
            }

            return builder.ToString();
        }
    }
}