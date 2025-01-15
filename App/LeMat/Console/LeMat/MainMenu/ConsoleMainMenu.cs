using LeMat.Factories;
using LeMat.Interfaces;
using LeMat.Utilities;

namespace LeMat.MainMenu
{
    /// <summary>
    /// Represents the console-based main menu for the application.
    /// </summary>
    internal class ConsoleMainMenu
    {
        /// <summary>
        /// User interface abstraction for input and output operations.
        /// </summary>
        private readonly IUserInterface _ui;

        /// <summary>
        /// Menu options displayed to the user.
        /// </summary>
        private readonly string[] _options = ["Don Quixote", "Monty Hall", "Schroedinger's Cat", "Byzantine Generals", "Exit"];

        /// <summary>
        /// The starting line position for rendering the menu in the console.
        /// </summary>
        private int _menuStartLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleMainMenu"/> class.
        /// Sets up the user interface and configures the console window size and color scheme.
        /// </summary>
        /// <param name="ui">An instance of <see cref="IUserInterface"/> used for UI operations like rendering content.</param>
        public ConsoleMainMenu(IUserInterface ui)
        {
            // Initialize the user interface by assigning the provided 'ui' parameter.
            _ui = ui;

            // Set the console window size to predefined limits for a consistent user experience.
            Utilities_Console.ConsoleWindowSize();

            // Apply the default console colors for the main menu interface.
            Utilities_Console.ConsoleMainColors();
        }

        /// <summary>
        /// Displays the menu to the user, allowing them to navigate through the options 
        /// using the arrow keys and select an option using the Enter key.
        /// </summary>
        public void Show()
        {
            // Boolean flag to control the loop. Set to false to exit the loop.
            bool exit = false;

            // Index of the currently selected menu option.
            int selectedOption = 0;

            // Index of the previously selected option, initialized to an invalid value (-1).
            int previousOption = -1;

            // Clear the screen before rendering the menu.
            _ui.Clear();

            // Display the introductory content of the menu (e.g., title, description).
            DisplayIntro();

            // Calculate where the menu should start vertically for centering.
            CalculateMenuStartLine();

            // Render the full menu with the current selected option.
            RenderFullMenu(selectedOption);

            // Hide the cursor while the menu is displayed.
            Console.CursorVisible = false;

            // Store the initial window dimensions to track resizing.
            int previousWidth = Console.WindowWidth;
            int previousHeight = Console.WindowHeight;

            // Loop to keep the menu active until the user exits.
            while (!exit)
            {
                // If the window size has changed, re-render the menu to adapt to the new dimensions.
                if (Console.WindowWidth != previousWidth || Console.WindowHeight != previousHeight)
                {
                    // Update the previous dimensions to the new values.
                    previousWidth = Console.WindowWidth;
                    previousHeight = Console.WindowHeight;

                    // Clear the screen and re-render the intro and menu.
                    _ui.Clear();
                    DisplayIntro();
                    CalculateMenuStartLine();
                    RenderFullMenu(selectedOption);

                    // Hide the cursor again after resizing.
                    Console.CursorVisible = false;
                }

                // Check if a key is pressed, and handle user input.
                if (Console.KeyAvailable)
                {
                    // Read the pressed key.
                    var key = Console.ReadKey(true);

                    // Process the key press to navigate or select options.
                    switch (key.Key)
                    {
                        // If the up arrow key is pressed, select the previous option (wrap around if at the top).
                        case ConsoleKey.UpArrow:
                            selectedOption = (selectedOption == 0) ? _options.Length - 1 : selectedOption - 1;
                            break;

                        // If the down arrow key is pressed, select the next option (wrap around if at the bottom).
                        case ConsoleKey.DownArrow:
                            selectedOption = (selectedOption == _options.Length - 1) ? 0 : selectedOption + 1;
                            break;

                        // If Enter is pressed, handle the selected option.
                        case ConsoleKey.Enter:
                            HandleOption(selectedOption, ref exit);
                            break;

                        // Default case: No action for other keys.
                        default:
                            break;
                    }
                }

                // If the selected option has changed, update the menu display.
                if (selectedOption != previousOption)
                {
                    // Update the menu to reflect the change in selection.
                    UpdateMenu(previousOption, selectedOption);

                    // Update the previous option to the current one.
                    previousOption = selectedOption;
                }

                // Briefly pause to prevent excessive CPU usage while waiting for user input.
                Thread.Sleep(50);
            }

            // Show the cursor again once the menu is no longer being displayed.
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Displays the introductory text and title of the application.
        /// </summary>
        private void DisplayIntro()
        {
            _ui.WriteLine("");                                                                                      // 1
            CenterLineToWindow("██╗     ███████╗    ███╗   ███╗ █████╗ ████████╗");                                 // 2
            CenterLineToWindow("██║     ██╔════╝    ████╗ ████║██╔══██╗╚══██╔══╝");                                 // 3
            CenterLineToWindow("██║     █████╗      ██╔████╔██║███████║   ██║   ");                                 // 4
            CenterLineToWindow("██║     ██╔══╝      ██║╚██╔╝██║██╔══██║   ██║   ");                                 // 5
            CenterLineToWindow("███████╗███████╗    ██║ ╚═╝ ██║██║  ██║   ██║   ");                                 // 6
            CenterLineToWindow("╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ");                                 // 7
            _ui.WriteLine("");                                                                                      // 8
            CenterLineToWindow("Le Mat in tarot represents the beginning of a journey, freedom, spontaneity,");     // 9
            CenterLineToWindow("and infinite potential. It symbolizes the courage to embrace the unknown,");        // 10
            CenterLineToWindow("trusting the present, and letting go of fear.");                                    // 11
            _ui.WriteLine("");                                                                                      // 12       
        }

        /// <summary>
        /// Centers the given text horizontally in the console window and prints it on a new line.
        /// </summary>
        /// <param name="text">The text to be centered and displayed in the console window.</param>
        private void CenterLineToWindow(string text)
        {
            // Calculate the number of spaces needed to center the text horizontally
            // by subtracting the text length from the console window width and dividing by 2
            int leftPadding = (Console.WindowWidth - text.Length) / 2;

            // Write a line with the calculated padding followed by the text
            // Ensure the padding is non-negative by using Math.Max(0, leftPadding)
            // In case the text is longer than the console window width, leftPadding will be zero
            _ui.WriteLine(new string(' ', Math.Max(0, leftPadding)) + text);
        }

        /// <summary>
        /// Renders a single line of the menu, centered in the console, 
        /// and applies a different color scheme if the option is selected.
        /// </summary>
        /// <param name="text">The text of the menu option to render.</param>
        /// <param name="isSelected">Indicates whether the option is selected. If true, 
        /// the option will be rendered with a highlighted color; otherwise, the default color will be used.</param>
        private void RenderMenuLine(string text, bool isSelected)
        {
            // Apply the appropriate color scheme based on whether the option is selected
            Utilities_Console.ConsoleMenuColors(isSelected);

            // Clear the current line by writing spaces equal to the console width
            // This ensures that the menu option is properly rendered without remnants from previous lines
            _ui.Write(new string(' ', Console.WindowWidth));

            // Set the cursor position to the center of the current line for rendering the text
            // The position is calculated by subtracting the text length from the console width
            // and dividing the result by 2 to center the text
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);

            // Render the text of the menu option at the current cursor position
            _ui.Write(text);

            // Reset the console colors to default after rendering the option
            Console.ResetColor();
        }

        /// <summary>
        /// Calculates the starting line for rendering the menu in the console, 
        /// so that the menu is vertically centered based on the console's height.
        /// </summary>
        private void CalculateMenuStartLine()
        {
            // Determine the total height of the menu by getting the number of options
            int menuHeight = _options.Length;

            // Calculate the starting line to center the menu vertically on the console
            //_menuStartLine = ((Console.WindowHeight - menuHeight) / 2);

            // Number of rows from the top of the window to starting the line.
            // See DisplayIntro() to understand why 13.
            _menuStartLine = 13;
        }

        /// <summary>
        /// Renders the full menu, highlighting the currently selected option.
        /// </summary>
        /// <param name="selectedOption">The index of the currently selected option. 
        /// This option will be rendered with a highlighted style.</param>
        private void RenderFullMenu(int selectedOption)
        {
            // Loop through all menu options to render each one
            for (int i = 0; i < _options.Length; i++)
            {
                // Render each option, highlighting the selected one
                RenderOption(i, i == selectedOption);
            }
        }

        /// <summary>
        /// Updates the menu rendering when the selection changes.
        /// </summary>
        /// <param name="previousOption">The index of the previously selected option.</param>
        /// <param name="currentOption">The index of the currently selected option.</param>
        private void UpdateMenu(int previousOption, int currentOption)
        {
            if (previousOption >= 0)
            {
                // Deselect the previous option.
                RenderOption(previousOption, false);
            }
            if (currentOption >= 0)
            {
                // Highlight the current option.
                RenderOption(currentOption, true);
            }
        }

        /// <summary>
        /// Renders a single menu option at a specific position in the console, 
        /// optionally highlighting it if it is selected.
        /// </summary>
        /// <param name="index">The index of the menu option to render. It determines the vertical position in the menu.</param>
        /// <param name="isSelected">Indicates whether the option is selected. If true, the option will be highlighted; otherwise, it will be rendered normally.</param>
        private void RenderOption(int index, bool isSelected)
        {
            // Set the cursor position to the start of the current menu option
            Console.SetCursorPosition(0, _menuStartLine + index);

            // Clear the current line by writing spaces equal to the console width
            // This ensures any previously rendered option doesn't overlap with the new one
            _ui.Write(new string(' ', Console.WindowWidth));

            // Reset the cursor position to the start of the current option
            Console.SetCursorPosition(0, _menuStartLine + index);

            // Retrieve the text for the current menu option using the provided index
            string text = _options[index];

            // Render the menu line, highlighting it if the option is selected
            RenderMenuLine(text, isSelected);

            // Reset the console colors to default after rendering the option
            Console.ResetColor();
        }

        /// <summary>
        /// Handles the logic for the selected menu option.
        /// </summary>
        /// <param name="selectedOption">The index of the selected option.</param>
        /// <param name="exit">Reference to the exit flag to terminate the menu loop.</param>
        private void HandleOption(int selectedOption, ref bool exit)
        {
            _ui.Clear();
            _ui.WriteLine($"Selection: {_options[selectedOption]}");

            if (_options[selectedOption] == "Exit")
            {
                // Exit the menu.
                exit = true;
            }
            else
            {
                _ui.WriteLine($"Loading {_options[selectedOption]}...");
                _ui.Clear();

                // Launch the selected game.
                FactoryGames.SelectGame(selectedOption);

                _ui.Clear();

                // Redisplay the intro after the game exits.
                DisplayIntro();
                CalculateMenuStartLine();
                RenderFullMenu(selectedOption);
            }
        }
    }
}
