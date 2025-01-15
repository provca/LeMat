using ThreeDoors.Game;
using ThreeDoors.Interfaces;
using ThreeDoors.Logic;

namespace LeMat.Games.MontyHallProblem
{
    /// <summary>
    /// Represents the Monty Hall Problem game implementation.
    /// </summary>
    internal class MontyHallProblemGame
    {
        /// <summary>
        /// User interface abstraction for input and output operations.
        /// </summary>
        private readonly IUserInterface _ui;

        /// <summary>
        /// Initializes a new instance of the <see cref="MontyHallProblemGame"/> class.
        /// </summary>
        /// <param name="ui">The user interface to interact with.</param>
        public MontyHallProblemGame(IUserInterface ui)
        {
            _ui = ui;
        }

        /// <summary>
        /// Initializes the game and displays the welcome message.
        /// </summary>
        public void Initialize()
        {
            // Show the initial game instructions.
            DisplayWelcomeMessage();

            // Start the game loop.
            RunGameLoop();
        }

        /// <summary>
        /// Displays the welcome message for the game.
        /// </summary>
        private void DisplayWelcomeMessage()
        {
            _ui.WriteLine(
                "Imagine you're on a game show. You must choose one of three doors.\n" +
                "Behind one is a prize, and behind the other two, nothing.\n\n" +
                "1. Pick a door.\n" +
                "2. The host reveals an empty door.\n" +
                "3. Decide: stick with your choice or switch?\n\n" +
                "> Will you trust your instincts or the odds? Play multiple rounds, analyze statistics,\n" +
                "  and you might be surprised by what the winning strategy could be the best.\n"
            );
        }

        /// <summary>
        /// Handles the game loop, allowing the user to play or exit.
        /// </summary>
        private void RunGameLoop()
        {
            while (true)
            {
                _ui.Write("> Press any key to play or 'Q' to exit: ");
                string? input = _ui.ReadLine()?.Trim().ToLower();

                if (input == "q")
                {
                    // Exit the game if the user presses 'Q'.
                    ExitGame();
                    return;
                }

                // Clear the interface for the next round.
                _ui.Clear();

                // Execute the game logic.
                int p = Play();
                if (p < 0)
                    break;
            }
        }

        /// <summary>
        /// Executes the game logic.
        /// </summary>
        private int Play()
        {
            _ui.Clear();

            // Create instances of the necessary components for the game.
            RandomGenerator randomGenerator = new();
            StatisticsManager statisticsManager = new();
            Game game = new(randomGenerator, _ui, statisticsManager);

            // Display a welcome message to the player.
            _ui.WriteLine("Welcome to the Monty Hall game!");

            // Main game loop to allow multiple rounds of play.
            while (true)
            {
                // Play a single round of the game.
                int q = game.PlayRound();

                // Quit game.
                if (q < 0)
                    return -1;

                // Ask the player if they want to play another round.
                _ui.WriteLine("Do you want to play again? (y/n):");

                // Exit the loop if the player doesn't want to continue.
                if (_ui.ReadLine().ToLower() != "y")
                    break;

                // Clear the console for the next round.
                _ui.Clear();
            }

            // Clear the console before displaying final statistics.
            _ui.Clear();

            // Display the game statistics after the game ends.
            statisticsManager.DisplayStatistics(_ui);

            // Thank the player for playing.
            _ui.WriteLine("Thanks for playing!\n");

            return 0;
        }

        /// <summary>
        /// Displays the exit message and pauses before quitting.
        /// </summary>
        private void ExitGame()
        {
            _ui.WriteLine("Exiting the game...");

            // Pause for 2 seconds before exiting.
            Thread.Sleep(2000);
        }
    }
}
