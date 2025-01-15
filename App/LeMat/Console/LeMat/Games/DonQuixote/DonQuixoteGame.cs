using ChasingWindmillsInLogic.ChasingWindmills;
using LeMat.Interfaces;

namespace LeMat.Games.DonQuixote
{
    /// <summary>
    /// Represents the Don Quixote game where logic battles an unsolvable paradox.
    /// </summary>
    internal class DonQuixoteGame
    {
        /// <summary>
        /// User interface abstraction for input and output operations.
        /// </summary>
        private readonly IUserInterface _ui;

        /// <summary>
        /// Initializes a new instance of the <see cref="DonQuixoteGame"/> class.
        /// </summary>
        /// <param name="ui">The user interface to interact with.</param>
        public DonQuixoteGame(IUserInterface ui)
        {
            _ui = ui;
        }

        /// <summary>
        /// Initializes the game and displays an introductory message.
        /// </summary>
        public void Initialize()
        {
            _ui.WriteLine(
                "\"The Madness of Logic\" like Don Quixote tilting at windmills,\n" +
                "this C# algorithm valiantly battles a paradox it cannot defeat.\n" +
                "It claims the opposite of its own truth, chasing an answer\n" +
                "that leads only to a logical collapse—a stack overflow.\n" +
                "What does this mean? Perhaps some questions are not meant to be answered...\n\n"
            );

            // Execute the main game logic.
            Play();

            // Wait for user input before exiting.
            _ui.ReadLine();
        }

        /// <summary>
        /// Executes the main game logic where a logical paradox is evaluated.
        /// </summary>
        private void Play()
        {
            try
            {
                // Attempt to evaluate the paradox by calling the recursive method.
                bool result = Game.ChasingWindmills(0);

                // Display the result of the paradox evaluation.
                _ui.WriteLine("> Is the proposition true? " + result);
            }
            catch (StackOverflowException)
            {
                // Handle stack overflow and provide a dramatic philosophical response.
                _ui.WriteLine(
                    "> Alas! The logic crumbles beneath its own weight.\n" +
                    "> What is truth, if not a fleeting mirage?"
                );
            }
        }
    }
}

