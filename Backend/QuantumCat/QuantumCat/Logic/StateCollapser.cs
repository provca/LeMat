using QuantumCat.Interfaces;

namespace QuantumCat.Logic
{
    /// <summary>
    /// Handles the collapse of the quantum state.
    /// </summary>
    internal class StateCollapser : IStateCollapser
    {
        /// <inheritdoc />
        public string CollapseState(double aliveProbability)
        {
            // Generate a random number to decide the state based on the given probability.
            Random random = new();
            return random.NextDouble() < aliveProbability ? "alive" : "dead";
        }
    }
}
