using ByzantineConsensus.Factories;
using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Play;

namespace LeMat.Games.ByzantineGenerals
{
    /// <summary>
    /// Represents the Byzantine Generals game implementation.
    /// </summary>
    internal class ByzantineGeneralsGame
    {
        /// <summary>
        /// User interface abstraction for input and output operations.
        /// </summary>
        private readonly IUserInterface _ui;

        /// <summary>
        /// Initializes a new instance of the <see cref="ByzantineGeneralsGame"/> class.
        /// </summary>
        /// <param name="ui">The user interface to interact with.</param>
        public ByzantineGeneralsGame(IUserInterface ui)
        {
            _ui = ui;
        }

        /// <summary>
        /// Initializes the game and displays the welcome message.
        /// </summary>
        public void Initialize()
        {
            DisplayWelcomeMessage(); // Show the initial game instructions.
            RunGameLoop(); // Start the game loop.
        }

        /// <summary>
        /// Displays the welcome message for the game.
        /// </summary>
        private void DisplayWelcomeMessage()
        {
            _ui.WriteLine(
                "Welcome to the Byzantine Generals Game:\n" +
                "A strategic journey through loyalty, betrayal, and the art of persuasion!\n\n" +
                "In a kingdom on the brink of war, you are the King. Your mission?\n" +
                "> Unite your generals, outsmart traitors, and secure victory.\n" +
                "> But beware: every decision carries the weight of empire.\n"
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
                Play();
            }
        }

        /// <summary>
        /// Executes the game logic.
        /// </summary>
        private void Play()
        {
            // Initialize the game with the specified number of generals.
            Game gameService = new GameFactory().CreateGame(_ui, 5);

            // Start the game.
            gameService.Initialize();
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
