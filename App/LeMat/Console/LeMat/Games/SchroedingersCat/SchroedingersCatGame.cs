using QuantumCat.Game;
using QuantumCat.Interfaces;

namespace LeMat.Games.SchroedingersCat
{
    /// <summary>
    /// Represents the Schrödinger's Cat game implementation.
    /// </summary>
    internal class SchroedingersCatGame
    {
        /// <summary>
        /// User interface abstraction for input and output operations.
        /// </summary>
        private readonly IUserInterface _ui;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchroedingersCatGame"/> class.
        /// </summary>
        /// <param name="ui">The user interface to interact with.</param>
        public SchroedingersCatGame(IUserInterface ui)
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
                "Welcome to the Schrödinger's Cat Quantum Experiment!\n\n" +
                "Imagine a closed box containing a cat in a mysterious quantum state: Simultaneously alive and dead.\n" +
                "Only by observing the box will this state \"collapse\" into a definitive reality—either the cat is alive or dead.\n" +
                "Are you ready to open the box and uncover the cat's fate?\n"
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
            // Initialize the game logic with the user interface.
            Game game = new(_ui);

            // Start the game.
            game.Initialize();
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
