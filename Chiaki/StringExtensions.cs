using System;
using System.Collections.Generic;
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
        private static readonly Random _random = new Random();

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
        /// Removes whitespace, tabs, carriage returns, new lines, vertical tabs and form feed characters from a string.
        /// </summary>
        /// <remarks>
        /// This method uses Regex \s to match.
        /// </remarks>
        public static string RemoveWhitespace(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Regex.Replace(input, @"\s", string.Empty);
        }

        /// <summary>
        /// Removes all HTML tags from a string.
        /// </summary>
        public static string RemoveHtmlTags(this string input)
        {
            const string pattern = @"<(.|\n)*?>";

            return Regex.Replace(input, pattern, string.Empty, RegexOptions.Compiled);
        }

        /// <summary>
        /// Removes all carriage returns and newlines from a string.
        /// </summary>
        public static string RemoveNewLines(this string input)
        {
            return input
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty);
        }

        /// <summary>
        /// Converts all new lines characters "\n" to html break tags.
        /// </summary>
        public static string ConvertNewLinesToHtmlTags(this string input)
        {
            return input
                .Replace("\r", string.Empty)
                .Replace("\n", "<br />");
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
        /// Truncates a string to the specified max length.
        /// </summary>
        public static string TruncateTo(this string input, int maxLength, string suffix = "...")
        {
            string text = input;

            if (maxLength <= 0)
            {
                return text;
            }

            int length = maxLength - suffix.Length;

            if (length <= 0 || input == null || input.Length <= maxLength)
            {
                return text;
            }

            return text.Substring(0, length).TrimEnd() + suffix;
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        public static string Formatted(this string input, object arg0)
        {
            return string.Format(input, arg0);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        public static string Formatted(this string input, params object[] args)
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
        /// Gets all characters of the string using UTF8 encoding and encodes them into a byte array.
        /// </summary>
        public static byte[] GetBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// Replaces the first occurence of a string within a string, and replaces it with another string.
        /// </summary>
        /// <param name="text">The string to perform the replacements on.</param>
        /// <param name="search">The string to match.</param>
        /// <param name="replace">The string that will be inserted if the first match is found.</param>
        /// <returns></returns>
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            int position = text.IndexOf(search, StringComparison.Ordinal);

            if (position < 0)
            {
                return text;
            }

            return text.Substring(0, position) + replace + text.Substring(position + search.Length);
        }

        /// <summary>
        /// Generates a string with random characters. 
        /// </summary>
        /// <remarks>Use of this method for anything security related is not recommended.</remarks>
        /// <param name="characters">Characters that can be chosen as part of the randomisation process.</param>
        /// <param name="length">The length of the randomised string to generate.</param>
        [Obsolete("Use Random.GenerateString instead. This method will be removed in a future version.")]
        public static string GenerateRandomString(string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", int length = 8) => _random.GenerateString(characters, length);

        /// <summary>
        /// Creates a string with the specified length with the input string centered.
        /// </summary>
        /// <param name="input">String to center</param>
        /// <param name="totalLength">Total length of the output string</param>
        /// <returns></returns>
        public static string CenterString(this string input, int totalLength)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            int length = input.Length;
            int left = (totalLength - length) / 2 + length;

            if (left < 0)
            {
                return input;
            }

            return input
                .PadLeft(left)
                .PadRight(totalLength);
        }

        /// <summary>
        /// Splits a string by any camel case.
        /// </summary>
        public static IEnumerable<string> SplitByCamelCase(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            const string pattern = @"[A-Z][a-z]*|[a-z]+|\d+";
            var matches = Regex.Matches(source, pattern);
            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }

        /// <summary>
        /// Converts a string into a <see cref="System.Security.SecureString"/>.
        /// </summary>
        public static System.Security.SecureString ToSecureString(this string input)
        {
            var result = new System.Security.SecureString();

            for (var i = 0; i < input.Length; i++)
            {
                char c = input[i];
                result.AppendChar(c);
            }

            return result;
        }
    }
}
