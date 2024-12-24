namespace QuantumCat.Interfaces
{
    /// <summary>
    /// Defines an interface for collapsing quantum states.
    /// </summary>
    internal interface IStateCollapser
    {
        /// <summary>
        /// Collapses the quantum state into either "alive" or "dead".
        /// </summary>
        /// <param name="aliveProbability">The probability of the cat being alive.</param>
        /// <returns>A string indicating the collapsed state ("alive" or "dead").</returns>
        string CollapseState(double aliveProbability);
    }
}
