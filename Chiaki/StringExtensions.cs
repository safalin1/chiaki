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