using QuantumCat.Interfaces;
using QuantumCat.Logic;
using QuantumCat.Model;

namespace QuantumCat.Game
{
    /// <summary>
    /// Manages the flow of the quantum cat experiment game.
    /// </summary>
    public class Game
    {
        private readonly IStartExperiment _startExperiment;
        private readonly IUserInterface _ui;
        private readonly QuantumCatModel _model;
        private readonly IProbabilityCalculator _probabilityCalculator;
        private readonly IStateCollapser _stateCollapser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="ui">The user interface for interacting with the player.</param>
        public Game(IUserInterface ui)
        {
            _ui = ui;
            _model = new QuantumCatModel();
            _probabilityCalculator = new ProbabilityCalculator();
            _stateCollapser = new StateCollapser();
            _startExperiment = new StartExperiment();
        }

        /// <summary>
        /// Starts and manages the main game loop.
        /// </summary>
        public void Initialize()
        {
            // Display the introduction to the experiment.
            _startExperiment.Start(_ui);

            while (true)
            {
                _ui.Write("\nWhat would you like to do? ");
                string? input = _ui.ReadLine();

                if (input == null)
                {
                    // Handle empty input gracefully.
                    _ui.WriteLine("No input provided. Please try again.");
                    continue;
                }

                input = input.ToLower();

                // Handle quit command.
                if (input == "q")
                {
                    _ui.WriteLine("You have left the experiment. The cat remains in its quantum state.");
                    break;
                }

                // Handle state command to show the quantum probabilities.
                if (input == "s")
                {
                    if (!_model.Observed)
                    {
                        // Adjust the alive probability if the system is unobserved.
                        _model.AliveProbability = _probabilityCalculator.FluctuateProbability(_model.AliveProbability);
                        _ui.WriteLine($"Wave state: Alive {_model.AliveProbability * 100:F2}% | Dead {(1 - _model.AliveProbability) * 100:F2}%.");
                    }
                    else
                    {
                        _ui.WriteLine("The cat's state is already observed and collapsed. Do you want to restart the experiment? (Yes/No)");

                        input = _ui.ReadLine().ToLower();
                        if (input == "y")
                        {
                            _startExperiment.Restart(_model, _ui);
                        }
                        else
                        {
                            _ui.WriteLine("Thanks for playing!");
                        }
                    }
                }

                // Handle observe command to collapse the state.
                else if (input == "o")
                {
                    string state = _stateCollapser.CollapseState(_model.AliveProbability);
                    _ui.WriteLine($"You observed the system! The cat is: {state}.");
                    _ui.WriteLine("The cat has broken its quantum state. Do you want to restart the experiment? (Yes/No)");

                    input = _ui.ReadLine().ToLower();
                    if (input == "y")
                    {
                        _startExperiment.Restart(_model, _ui);
                    }
                    else
                    {
                        _ui.WriteLine("Thanks for playing!");
                        break;
                    }
                }
                else
                {
                    // Handle unrecognized commands.
                    _ui.WriteLine("Unrecognized command. Try 'O' (observe), 'S' (state), or 'Q' (exit).");
                }
            }
        }
    }
}
