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

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        public static string Format(this string input, object arg0)
        {
            return string.Format(input, arg0);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        public static string Format(this string input, params object[] args)
        {
            return string.Format(input, args);
        }

        /// <summary>
        /// Checks whether or not the string is numeric.
        /// </summary>
        public static bool IsNumeric(this string input)
        {
            return long.TryParse(input, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out _);
        }

        /// <summary>
        /// Returns true if the string is non-null and at least the specified number of characters.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <param name="length">The minimum length.</param>
        /// <returns>True if string is non-null and at least the length specified.</returns>
        /// <exception>throws ArgumentOutOfRangeException if length is not a non-negative number.</exception>
        public static bool IsLengthAtLeast(this string input, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "The length must be a non-negative number.");
            }

            return input != null && input.Length >= length;
        }

        /// <summary>
        /// Mask the source string with the mask char except for the last exposed digits.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="maskChar">The character to use to mask the source.</param>
        /// <param name="numExposed">Number of characters exposed in masked value.</param>
        /// <param name="style">The masking style to use (all characters or just alpha numerical characters).</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, char maskChar, int numExposed, StringMaskStyle style)
        {
            var maskedString = sourceValue;

            if (sourceValue.IsLengthAtLeast(numExposed))
            {
                var builder = new StringBuilder(sourceValue.Length);
                int index = maskedString.Length - numExposed;

                if (style == StringMaskStyle.AlphaNumericOnly)
                {
                    CreateAlphaNumMask(builder, sourceValue, maskChar, index);
                }
                else
                {
                    builder.Append(maskChar, index);
                }

                builder.Append(sourceValue.Substring(index));
                maskedString = builder.ToString();
            }

            return maskedString;
        }

        /// <summary>
        /// Mask the source string with the mask char except for the last exposed digits.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="maskChar">The character to use to mask the source.</param>
        /// <param name="numExposed">Number of characters exposed in masked value.</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, char maskChar, int numExposed)
        {
            return Mask(sourceValue, maskChar, numExposed, StringMaskStyle.All);
        }

        /// <summary>
        /// Mask the source string with the mask char.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="maskChar">The character to use to mask the source.</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, char maskChar)
        {
            return Mask(sourceValue, maskChar, 0, StringMaskStyle.All);
        }

        /// <summary>
        /// Mask the source string with the default mask char except for the last exposed digits.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="numExposed">Number of characters exposed in masked value.</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, int numExposed)
        {
            return Mask(sourceValue, '*', numExposed, StringMaskStyle.All);
        }

        /// <summary>
        /// Mask the source string with the default mask char.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue)
        {
            return Mask(sourceValue, '*', 0, StringMaskStyle.All);
        }

        /// <summary>
        /// Mask the source string with the mask char.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="maskChar">The character to use to mask the source.</param>
        /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, char maskChar, StringMaskStyle style)
        {
            return Mask(sourceValue, maskChar, 0, style);
        }

        /// <summary>
        /// Mask the source string with the default mask char except for the last exposed digits.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="numExposed">Number of characters exposed in masked value.</param>
        /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, int numExposed, StringMaskStyle style)
        {
            return Mask(sourceValue, '*', numExposed, style);
        }

        /// <summary>
        /// Mask the source string with the default mask char.
        /// </summary>
        /// <param name="sourceValue">Original string to mask.</param>
        /// <param name="style">The masking style to use (all characters or just alpha-nums).</param>
        /// <returns>The masked account number.</returns>
        public static string Mask(this string sourceValue, StringMaskStyle style)
        {
            return Mask(sourceValue, '*', 0, style);
        }

        /// <summary>
        /// Masks all characters for the specified length.
        /// </summary>
        /// <param name="buffer">String builder to store result in.</param>
        /// <param name="source">The source string to pull non-alpha numeric characters.</param>
        /// <param name="mask">Masking character to use.</param>
        /// <param name="length">Length of the mask.</param>
        private static void CreateAlphaNumMask(StringBuilder buffer, string source, char mask, int length)
        {
            for (int i = 0; i < length; i++)
            {
                buffer.Append(char.IsLetterOrDigit(source[i])
                                ? mask
                                : source[i]);
            }
        }

        /// <summary>
        /// Gets all characters of the string and encodes them into a byte array.
        /// </summary>
        public static byte[] GetBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// Truncates a string 
        /// </summary>
        public static string Truncate(this string input, int maxLength, string suffix = "...")
        {
            if (maxLength <= 0)
            {
                return input;
            }

            var length = maxLength - suffix.Length;

            if (length <= 0)
            {
                return input;
            }

            if (input == null || input.Length <= maxLength)
            {
                return input;
            }

            var result = input.Substring(0, length);
            result = result.TrimEnd();
            result += suffix;

            return result;
        }
    }
}