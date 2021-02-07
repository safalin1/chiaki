﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

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
                return null;
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
                return null;
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

            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return Regex.Replace(input, pattern, string.Empty, RegexOptions.Compiled);
        }

        /// <summary>
        /// Removes all carriage returns and newlines from a string.
        /// </summary>
        public static string RemoveNewLines(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return input
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty);
        }

        /// <summary>
        /// Converts all new lines characters "\n" to html break tags.
        /// </summary>
        public static string ConvertNewLinesToHtmlTags(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

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
                return input;
            }

            var builder = new StringBuilder(input.Length);

            foreach (char c in input)
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
            if (hexadecimal == null)
            {
                throw new ArgumentNullException(nameof(hexadecimal));
            }

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

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                result.AppendChar(c);
            }

            return result;
        }

        /// <summary>
        /// An extension method that returns a new string in which all occurrences of a 
        /// specified string in the current instance are replaced with another specified string.
        /// StringComparison specifies the type of search to use for the specified string.
        /// </summary>
        /// <param name="source">Current instance of the string</param>
        /// <param name="oldString">Specified string to replace</param>
        /// <param name="newString">Specified string to inject</param>
        /// <param name="stringComparison">String Comparison object to specify search type</param>
        /// <returns>Updated string</returns>
        public static string Replace(this string source, string oldString, string newString, StringComparison stringComparison)
        {
            int index = -1 * newString.Length;

            while ((index = source.IndexOf(oldString, index + newString.Length, stringComparison)) >= 0)
            {
                source = source.Remove(index, oldString.Length);

                source = source.Insert(index, newString);
            }

            return source;
        }

        /// <summary>
        /// Converts a string to Title Case, using the en-US culture.
        /// </summary>
        /// <returns>
        /// The input string modified to use title casing.
        /// </returns>
        public static string ToTitleCase(this string input) => input.ToTitleCase(new CultureInfo("en-US"));

        /// <summary>
        /// Converts a string to Title Case, using the specified <paramref name="cultureInfo"/>.
        /// </summary>
        /// <returns>
        /// The input string modified to use title casing.
        /// </returns>
        public static string ToTitleCase(this string input, CultureInfo cultureInfo)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            return cultureInfo.TextInfo.ToTitleCase(input);
        }

        /// <summary>
        /// Converts a string into an XML Document instance. 
        /// </summary>
        /// <param name="input">The XML string.</param>
        /// <exception cref="XmlException">Thrown if input string is not in valid XML format.</exception>
        public static XmlDocument ToXmlDocument(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var result = new XmlDocument();

            result.LoadXml(input);

            return result;
        }

        /// <summary>
        /// Converts a string into an XML Document instance. 
        /// </summary>
        /// <param name="input">The XML string.</param>
        /// <param name="xmlLoadOptions">Options for loading the XML.</param>
        /// <exception cref="XmlException">Thrown if input string is not in valid XML format.</exception>
        public static XDocument ToXDocument(this string input, LoadOptions xmlLoadOptions = LoadOptions.None)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return XDocument.Parse(input, xmlLoadOptions);
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="short" />.
        /// </summary>
        public static bool? TryParseBoolean(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return bool.TryParse(input, out bool buffer)
                ? buffer
                : (bool?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="short" />.
        /// </summary>
        public static int? TryParseInt16(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return short.TryParse(input, out short buffer)
                ? buffer
                : (short?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="int" />.
        /// </summary>
        public static int? TryParseInt32(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return int.TryParse(input, out int buffer)
                ? buffer
                : (int?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="long" />.
        /// </summary>
        public static long? TryParseInt64(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return long.TryParse(input, out long buffer)
                ? buffer
                : (long?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="DateTime"/>.
        /// </summary>
        public static DateTime? TryParseDateTime(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return DateTime.TryParse(input, out DateTime buffer)
                ? buffer
                : (DateTime?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="DateTimeOffset"/>.
        /// </summary>
        public static DateTimeOffset? TryParseDateTimeOffset(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return DateTimeOffset.TryParse(input, out DateTimeOffset buffer)
                ? buffer
                : (DateTimeOffset?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="double"/>.
        /// </summary>
        public static double? TryParseDouble(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return double.TryParse(input, out double buffer)
                ? buffer
                : (double?)null;
        }
        
        /// <summary>
        /// Tries to parse the input string as an <see cref="decimal"/>.
        /// </summary>
        public static decimal? TryParseDecimal(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return decimal.TryParse(input, out decimal buffer)
                ? buffer
                : (decimal?)null;
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="DateTimeOffset"/>.
        /// </summary>
        public static TimeSpan? TryParseTimeSpan(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return TimeSpan.TryParse(input, out TimeSpan buffer)
                ? buffer
                : (TimeSpan?)null;
        }

        /// <summary>
        /// Tries to parse an Enum from the string. 
        /// </summary>
        public static bool TryParseEnum<T>(this string input, out T enumValue, bool ignoreCase = false) where T : struct
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                enumValue = default;
                return false;
            }

            return Enum<T>.TryParse(input, ignoreCase, out enumValue);
        }

        /// <summary>
        /// Tries to parse the input string as an <see cref="Guid"/>.
        /// </summary>
        public static Guid? TryParseGuid(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return Guid.TryParse(input, out Guid buffer)
                ? buffer
                : (Guid?)null;
        }
        
        /// <summary>
        /// Tries to parse the input string as an <see cref="float"/>.
        /// </summary>
        public static float? TryParseSingle(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return float.TryParse(input, out float buffer)
                ? buffer
                : (float?)null;
        }

        /// <summary>
        /// Creates a URI from this string. 
        /// </summary>
        public static Uri ToUri(this string input, UriKind kind)
        {
            return new Uri(input, kind);
        }
    }
}
