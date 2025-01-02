using ByzantineConsensus.Factories;
using ByzantineConsensus.Game;
using ByzantineConsensus.Interfaces;
using ByzantineGenerals.User;

IUserInterface ui = new ConsoleUserInterface();
Game gameService = new GameFactory().CreateGame(ui, 4);
gameService.Initialize();
Console.ReadLine();