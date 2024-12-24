using QuantumCat.Game;
using SchroedingersCat.User;

// Create a user interface instance.
ConsoleUserInterface userInterface = new();

// Initialize the game logic with the user interface.
Game game = new(userInterface);

// Start the game.
game.Initialize();