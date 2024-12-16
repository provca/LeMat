using ThreeDoors.Interfaces;

namespace ThreeDoors.Logic
{
    /// <summary>
    /// Generates random numbers using a pseudo-random number generator.
    /// </summary>
    /// <seealso cref="IRandomGenerator" />
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class.
        /// </summary>
        public RandomGenerator()
        {
            // Initialize the random number generator with a seed based on a GUID.
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <inheritdoc />
        public int Next(int minValue, int maxValue)
        {
            // Returns a random number within the specified range.
            return _random.Next(minValue, maxValue);
        }
    }
}
