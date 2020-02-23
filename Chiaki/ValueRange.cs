using System;

namespace Chiaki
{
    /// <summary>
    /// Provides validation between a minimum and maximum of a value.
    /// </summary>
    public class ValueRange<T>
        where T : IComparable<T>
    {
        /// <summary>Minimum value of the range.</summary>
        public T Minimum { get; }

        /// <summary>Maximum value of the range.</summary>
        public T Maximum { get; }

        /// <summary>
        /// Creates a new instance of a ValueRange.
        /// </summary>
        /// <param name="minimum">Minimum possible value of the range.</param>
        /// <param name="maximum">Maximum possible value of the range.</param>
        public ValueRange(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;

            if (!IsValid())
            {
                throw new ArgumentException("Provided minimum and maximum values result in an invalid range.");
            }
        }

        /// <summary>Presents the Range in readable format.</summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString()
        {
            return $"{Minimum},{Maximum}";
        }

        /// <summary>Determines if the range is valid.</summary>
        /// <returns>True if range is valid, else false</returns>
        public bool IsValid()
        {
            return Minimum.CompareTo(Maximum) <= 0;
        }

        /// <summary>Determines if the provided value is inside the range.</summary>
        /// <param name="value">The value to test</param>
        /// <returns>True if the value is inside Range, else false</returns>
        public bool ContainsValue(T value)
        {
            return (Minimum.CompareTo(value) <= 0) && (value.CompareTo(Maximum) <= 0);
        }

        /// <summary>Determines if this Range is inside the bounds of another range.</summary>
        /// <param name="range">The parent range to test on</param>
        /// <returns>True if range is inclusive, else false</returns>
        public bool IsInsideRange(ValueRange<T> range)
        {
            return IsValid() && range.IsValid() && range.ContainsValue(Minimum) && range.ContainsValue(Maximum);
        }

        /// <summary>Determines if another range is inside the bounds of this range.</summary>
        /// <param name="range">The child range to test</param>
        /// <returns>True if range is inside, else false</returns>
        public bool ContainsRange(ValueRange<T> range)
        {
            return IsValid() && range.IsValid() && ContainsValue(range.Minimum) && ContainsValue(range.Maximum);
        }
    }
}
