using ThreeDoors.Interfaces;
using ThreeDoors.Logic;
using ThreeDoors.Models;

namespace ThreeDoors.Game
{
    /// <summary>
    /// Represents the core logic of the Three Doors game.
    /// </summary>
    public class Game
    {
        private readonly List<Door> _doors;
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUserInterface _ui;
        private readonly StatisticsManager _statisticsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="randomGenerator">An implementation of <see cref="IRandomGenerator"/> for generating random numbers.</param>
        /// <param name="ui">An implementation of <see cref="IUserInterface"/> for user interaction.</param>
        /// <param name="statisticsManager">Manages game statistics.</param>
        public Game(IRandomGenerator randomGenerator, IUserInterface ui, StatisticsManager statisticsManager)
        {
            _randomGenerator = randomGenerator;
            _ui = ui;
            _statisticsManager = statisticsManager;

            // Initialize the doors for the game.
            _doors = new List<Door> { new Door(), new Door(), new Door() };
        }

        /// <summary>
        /// Plays a single round of the game.
        /// </summary>
        public int PlayRound()
        {
            // Reset the state of all doors.
            ResetDoors();

            // Assign the prize to a random door.
            AssignPrizeToRandomDoor();

            // Get the player's initial choice of door.
            int chosenDoor = GetPlayerChoice();

            // Exit to game.
            if (chosenDoor < 0)
                return -1;

            // Reveal a door that is empty (does not have the prize).
            int revealedDoor = RevealEmptyDoor(chosenDoor);

            // Ask the player if they want to switch doors.
            bool wantsToSwitch = AskPlayerToSwitch();

            // Determine the player's final choice of door.
            int finalChoice = DetermineFinalChoice(chosenDoor, revealedDoor, wantsToSwitch);

            // Check if the player's final choice is the door with the prize.
            bool hasWon = _doors[finalChoice].HasPrize;

            // Display the outcome to the player.
            _ui.WriteLine($"Behind door {finalChoice + 1} is {(hasWon ? "the prize" : "nothing")}!");

            // Record the result of this round in the statistics manager.
            _statisticsManager.RecordResult(wantsToSwitch, hasWon);

            return 0;
        }

        /// <summary>
        /// Resets all doors to their initial state with no prizes.
        /// </summary>
        private void ResetDoors()
        {
            foreach (var door in _doors)
            {
                // Ensure each door has no prize initially.
                door.HasPrize = false;
            }
        }

        /// <summary>
        /// Randomly assigns the prize to one of the doors.
        /// </summary>
        private void AssignPrizeToRandomDoor()
        {
            // Generate a random index for the door that will have the prize.
            int prizeDoorIndex = _randomGenerator.Next(0, _doors.Count);
            _doors[prizeDoorIndex].HasPrize = true;
        }

        /// <summary>
        /// Prompts the player to choose a door.
        /// </summary>
        /// <returns>The index of the chosen door.</returns>
        private int GetPlayerChoice()
        {
            while (true)
            {
                _ui.WriteLine("Choose a door (1, 2, or 3) or press 'q' to quit:");

                string? input = _ui.ReadLine()?.Trim().ToLower();

                if (input == "q")
                {
                    _ui.WriteLine("Exiting the game...");
                    return -1;
                }

                // Parse the player's input and adjust for zero-based indexing.
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                {
                    // Adjust index by 0 position.
                    return choice - 1;
                }

                _ui.WriteLine("Invalid input. Please choose a valid door (1, 2, or 3) or 'q' to quit.");
            }
        }

        /// <summary>
        /// Reveals a door that is empty and not the player's chosen door.
        /// </summary>
        /// <param name="chosenDoor">The index of the door chosen by the player.</param>
        /// <returns>The index of the revealed door.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no empty door can be revealed.</exception>
        private int RevealEmptyDoor(int chosenDoor)
        {
            for (int i = 0; i < _doors.Count; i++)
            {
                // Ensure the revealed door is not the player's choice and does not have the prize.
                if (i != chosenDoor && !_doors[i].HasPrize)
                {
                    _ui.WriteLine($"The host opens door {i + 1}, and it is empty.");
                    return i;
                }
            }

            // This should never occur if the game setup is correct.
            throw new InvalidOperationException("No empty door was found to reveal.");
        }

        /// <summary>
        /// Asks the player if they want to switch their chosen door.
        /// </summary>
        /// <returns><c>true</c> if the player wants to switch; otherwise, <c>false</c>.</returns>
        private bool AskPlayerToSwitch()
        {
            _ui.WriteLine("Do you want to switch doors? (y/n):");
            return _ui.ReadLine().ToLower() == "y";
        }

        /// <summary>
        /// Determines the player's final choice of door based on their decision to switch or not.
        /// </summary>
        /// <param name="chosenDoor">The player's initial chosen door.</param>
        /// <param name="revealedDoor">The door that was revealed as empty.</param>
        /// <param name="wantsToSwitch">Indicates if the player wants to switch doors.</param>
        /// <returns>The index of the player's final chosen door.</returns>
        private int DetermineFinalChoice(int chosenDoor, int revealedDoor, bool wantsToSwitch)
        {
            if (wantsToSwitch)
            {
                // Get the other door that was not chosen or revealed.
                return GetOtherDoor(chosenDoor, revealedDoor);
            }

            // Return the player's original choice if they do not switch.
            return chosenDoor;
        }

        /// <summary>
        /// Finds the index of the door that was neither chosen nor revealed.
        /// </summary>
        /// <param name="chosenDoor">The player's initially chosen door.</param>
        /// <param name="revealedDoor">The door that was revealed as empty.</param>
        /// <returns>The index of the remaining door.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no other door is available.</exception>
        private int GetOtherDoor(int chosenDoor, int revealedDoor)
        {
            for (int i = 0; i < _doors.Count; i++)
            {
                // Find the door that was not chosen and not revealed.
                if (i != chosenDoor && i != revealedDoor)
                {
                    return i;
                }
            }

            // This should never occur if the game setup is correct.
            throw new InvalidOperationException("No other door was found.");
        }
    }
}
