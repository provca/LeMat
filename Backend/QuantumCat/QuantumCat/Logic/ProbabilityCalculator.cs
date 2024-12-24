using QuantumCat.Interfaces;

namespace QuantumCat.Logic
{
    /// <summary>
    /// Calculates probability fluctuations for the quantum cat state.
    /// </summary>
    internal class ProbabilityCalculator : IProbabilityCalculator
    {
        /// <inheritdoc />
        public double FluctuateProbability(double currentProbability)
        {
            // Generate a small random change to the current probability.
            Random random = new();
            double change = random.NextDouble() * 0.1;

            // Apply the change randomly as an increase or decrease, clamping between 0 and 1.
            return Math.Clamp(currentProbability + (random.Next(2) == 0 ? -change : change), 0.0, 1.0);
        }
    }
}
