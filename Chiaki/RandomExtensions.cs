using System;
// ReSharper disable UnusedMember.Global

namespace Chiaki
{
    /// <summary>
    /// Provides extensions for <see cref="Random"/>.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Gets a random double, between <paramref name="minValue"/> and <paramref name="maxValue"/>
        /// </summary>
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Gets a random float, between <paramref name="minValue"/> and <paramref name="maxValue"/>
        /// </summary>
        public static float NextFloat(
            this Random random,
            float minValue,
            float maxValue)
        {
            return (float)random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
