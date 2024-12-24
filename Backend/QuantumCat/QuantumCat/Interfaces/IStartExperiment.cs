using QuantumCat.Model;

namespace QuantumCat.Interfaces
{
    internal interface IStartExperiment
    {
        /// <summary>
        /// Displays the introduction and instructions for the experiment.
        /// </summary>
        /// <param name="ui">The user interface used for interaction.</param>
        void Start(IUserInterface ui);

        /// <summary>
        /// Resets the experiment to its initial state.
        /// </summary>
        /// <param name="model">The model representing the quantum cat experiment.</param>
        /// <param name="ui">The user interface used for interaction.</param>
        void Restart(QuantumCatModel model, IUserInterface ui);
    }
}
