namespace ByzantineConsensus.Logic.Utilities
{
    /// <summary>
    /// Provides methods for generating random values.
    /// </summary>
    internal static class RandomHelper
    {
        private static readonly Random RandomGenerator = new();

        /// <summary>
        /// Generates a random integer between the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <returns>A random integer within the range.</returns>
        public static int NextInt(int min, int max) => RandomGenerator.Next(min, max);

        /// <summary>
        /// Generates a random boolean value.
        /// </summary>
        /// <returns>A random boolean value.</returns>
        public static bool NextBool() => RandomGenerator.Next(0, 2) == 1;

        /// <summary>
        /// Generates a random double value between 0.0 and 1.0.
        /// </summary>
        /// <returns>A random double value.</returns>
        public static double NextDouble() => RandomGenerator.NextDouble();
    }
}
