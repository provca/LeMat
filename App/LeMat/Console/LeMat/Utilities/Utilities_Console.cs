namespace LeMat.Utilities
{
    /// <summary>
    /// Provides utility methods for configuring the console display.
    /// </summary>
    internal class Utilities_Console
    {
        /// <summary>
        /// Configures the console colors by setting the foreground and background colors.
        /// </summary>
        /// <remarks>
        /// This method sets the text color to yellow and the background color to dark blue.
        /// After setting the colors, it clears the console to apply the changes.
        /// </remarks>
        public static void ConsoleMainColors()
        {
            // Set the text color to yellow.
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Set the background color to dark blue.
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // Clear the console to apply the selected colors.
            Console.Clear();
        }

        /// <summary>
        /// Configures the console main menu colors by setting the foreground and background colors if item is focused.
        /// </summary>
        /// <param name="activated">
        /// Determinates if the item has the focus.
        /// </param>
        /// <remarks>
        /// This method sets the text color to white and the background color to blue if activated is true.
        /// If activated is false sets the text color to yellow and the background color to dark blue.
        /// </remarks>
        public static void ConsoleMenuColors(bool activated)
        {
            if (activated)
            {
                // Set the text color.
                Console.ForegroundColor = ConsoleColor.White;

                // Set the background color.
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                // Set the text color.
                Console.ForegroundColor = ConsoleColor.Yellow;

                // Set the background color.
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
        }

        /// <summary>
        /// Adjusts the size of the console window to a predefined maximum width and height.
        /// It sets the window to a maximum of 100 columns in width and 37 rows in height, 
        /// based on the system's largest window size, if possible.
        /// </summary>
        /// <remarks>
        /// This method handles possible <see cref="IOException"/> exceptions that may occur 
        /// during the process, such as issues with the console window resizing operation.
        /// </remarks>
        public static void ConsoleWindowSize()
        {
            try
            {
                // Retrieve the maximum allowable width for the console window
                int maxWidth = Console.LargestWindowWidth;

                // Retrieve the maximum allowable height for the console window
                int maxHeight = Console.LargestWindowHeight;

                // Set the console window size to the minimum of the predefined limits and the system's max values
                // Ensure the width does not exceed 100 and the height does not exceed 37
                Console.SetWindowSize(Math.Min(100, maxWidth), Math.Min(37, maxHeight));
            }
            catch (IOException)  // Catch IOExceptions that may occur during window resizing
            {
                // Log or handle the exception if necessary (currently empty catch block)
                // You can consider logging the error or providing feedback to the user.
            }
        }

    }
}
