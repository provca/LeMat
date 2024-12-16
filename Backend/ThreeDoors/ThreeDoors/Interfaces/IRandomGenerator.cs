namespace ThreeDoors.Interfaces
{
    /// <summary>
    /// Provides a mechanism to generate random numbers within a specified range.
    /// </summary>
    public interface IRandomGenerator
    {
        /// <summary>
        /// Generates a random number within the specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the range.</param>
        /// <param name="maxValue">The exclusive upper bound of the range.</param>
        /// <returns>A random integer between <paramref name="minValue"/> and <paramref name="maxValue"/>.</returns>
        int Next(int minValue, int maxValue);
    }
}
