using LeMat.Interfaces;
using LeMat.MainMenu;
using LeMat.User;

// Initialize User Interface.
IUserInterface ui = new ConsoleUserInterface();
ui.Clear();

// Display main menu.
var mainMenu = new ConsoleMainMenu(ui);
mainMenu.Show();