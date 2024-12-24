namespace QuantumCat.Model
{
    /// <summary>
    /// Represents the model of the quantum cat experiment.
    /// </summary>
    public class QuantumCatModel
    {
        /// <summary>
        /// Gets or sets whether the system has been observed, collapsing the quantum state.
        /// </summary>
        public bool Observed { get; set; } = false;

        /// <summary>
        /// Gets or sets the probability that the cat is alive before observation.
        /// </summary>
        public double AliveProbability { get; set; } = 0.5;
    }
}
