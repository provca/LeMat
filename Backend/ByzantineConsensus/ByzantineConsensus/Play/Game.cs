using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Logic;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Play
{
    /// <summary>
    /// Represents the main game logic for the Byzantine Generals' Problem simulation.
    /// </summary>
    public class Game
    {
        private readonly IUserInterface _ui;
        private readonly List<General> _listOfGenerals;
        private readonly IKing _king;
        private readonly IRounds _rounds;
        private readonly IStatistics _statistics;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="ui">The user interface used for interaction.</param>
        /// <param name="generals">The list of generals participating in the game.</param>
        public Game(IUserInterface ui, List<General> generals)
        {
            _ui = ui;
            _listOfGenerals = generals;

            // Instantiate the King, Rounds, and Statistics components.
            _king = new King();
            _rounds = new Rounds();
            _statistics = new Statistics();
        }

        /// <summary>
        /// Starts the simulation by initializing the game state and executing rounds.
        /// </summary>
        public void Initialize()
        {

            // Introduce the game and prompt for the King's initial decision.
            _ui.WriteLine("Welcome to the Byzantine Generals' Council.");
            _ui.WriteLine("You are the King. Decide whether to attack or retreat.");
            _ui.WriteLine("Beware: some generals may be traitors!\n");

            // Display initial statistics to the user.
            DisplayInitialStatistics();

            string initialDecision = _king.GetInitialDecision(_ui);

            // Distribute the King's initial decision to all generals.
            foreach (var general in _listOfGenerals)
                general.ReceivedOrder = initialDecision;

            // Execute the main rounds of the game.
            ExecuteRounds();

            // Display final statistics after the game ends.
            DisplayFinalStatistics();
        }

        /// <summary>
        /// Displays the initial statistics of the generals.
        /// </summary>
        private void DisplayInitialStatistics() =>
            _statistics.DisplayInitialStatistics(_listOfGenerals, _ui);

        /// <summary>
        /// Displays the final statistics of the generals.
        /// </summary>
        private void DisplayFinalStatistics() =>
            _statistics.DisplayFinalStatistics(_listOfGenerals, _ui);

        /// <summary>
        /// Executes the main rounds of the game, including persuasion and complot phases.
        /// </summary>
        private void ExecuteRounds() =>
            _rounds.ExecuteRounds(_ui, _listOfGenerals, _king, _statistics);
    }
}
