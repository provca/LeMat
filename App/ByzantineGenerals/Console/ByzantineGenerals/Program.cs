using ByzantineConsensus.Factories;
using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Play;
using ByzantineGenerals.User;

/// <summary>
/// Entry point for the Byzantine Generals' Problem simulation.
/// Main method to set up and start the game simulation.
/// </summary>

// Create the user interface instance.
IUserInterface ui = new ConsoleUserInterface();

// Initialize the game with the specified number of generals.
Game gameService = new GameFactory().CreateGame(ui, 4);

// Start the game.
gameService.Initialize();

// Wait for user input before closing.
Console.ReadLine();