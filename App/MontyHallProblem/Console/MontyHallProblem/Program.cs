using MontyHallProblem.User;
using ThreeDoors.Game;
using ThreeDoors.Logic;

// Create instances of the necessary components for the game.
ConsoleUserInterface ui = new();
RandomGenerator randomGenerator = new();
StatisticsManager statisticsManager = new();
Game game = new(randomGenerator, ui, statisticsManager);

// Display a welcome message to the player.
ui.WriteLine("Welcome to the Monty Hall game!");

// Main game loop to allow multiple rounds of play.
while (true)
{
    // Play a single round of the game.
    game.PlayRound();

    // Ask the player if they want to play another round.
    ui.WriteLine("Do you want to play again? (y/n):");

    // Exit the loop if the player doesn't want to continue.
    if (ui.ReadLine().ToLower() != "y")
        break;

    // Clear the console for the next round.
    Console.Clear();
}

// Clear the console before displaying final statistics.
Console.Clear();

// Display the game statistics after the game ends.
statisticsManager.DisplayStatistics(ui);

// Thank the player for playing.
ui.WriteLine("Thanks for playing!");

// Wait for the player to press a key before closing the application.
Console.ReadLine();
