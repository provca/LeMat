namespace QuantumCat.Interfaces
{
    /// <summary>
    /// Defines a contract for fluctuating probabilities in a quantum system.
    /// </summary>
    internal interface IProbabilityCalculator
    {
        /// <summary>
        /// Adjusts the current probability by introducing a small random fluctuation.
        /// </summary>
        /// <param name="currentProbability">The current probability value, ranging between 0.0 and 1.0.</param>
        /// <returns>The new probability value after fluctuation, clamped between 0.0 and 1.0.</returns>
        double FluctuateProbability(double currentProbability);
    }
}
