using QuantumCat.Interfaces;
using QuantumCat.Model;

namespace QuantumCat.Logic
{
    /// <summary>
    /// Provides methods to start and restart the quantum experiment.
    /// </summary>
    public class StartExperiment : IStartExperiment
    {
        /// <inheritdoc />
        public void Start(IUserInterface ui)
        {
            ui.WriteLine("Welcome to Schrödinger's Cat Quantum Experiment!");
            ui.WriteLine("Before observation, the cat exists in superposition (like a wave).\nUpon observation, the state collapses to a particle: 'alive' or 'dead'.");
            ui.WriteLine("Type 'O' (observe) to open the box and collapse the cat's state, or 'S' (state) to view the quantum wave.");
            ui.WriteLine("Type 'Q' (quit) to leave the experiment.");
        }

        /// <inheritdoc />
        public void Restart(QuantumCatModel model, IUserInterface ui)
        {
            // Reset the model properties.
            model.Observed = false;
            model.AliveProbability = 0.5;

            // Clear the console and restart the experiment.
            ui.Clear();
            Start(ui);
        }
    }
}
