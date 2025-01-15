using ByzantineConsensus.Interfaces;

namespace ByzantineConsensus.Logic.Utilities
{
    /// <summary>
    /// Provides helper methods for validating and sanitizing user input.
    /// </summary>
    internal static class InputHelper
    {
        /// <summary>
        /// Gets validated user input based on allowed options.
        /// </summary>
        /// <param name="ui">The user interface for interaction.</param>
        /// <param name="prompt">The message to display to the user.</param>
        /// <param name="validOptions">An array of valid input options.</param>
        /// <returns>A valid input string chosen by the user.</returns>
        public static string GetValidatedInput(IUserInterface ui, string prompt, string[] validOptions)
        {
            string input;
            do
            {
                ui.Write(prompt);
                input = ui.ReadLine()?.Trim().ToUpper() ?? string.Empty;

                if (!validOptions.Contains(input))
                {
                    ui.WriteLine($"Invalid input. Please choose one of the following: {string.Join(", ", validOptions)}");
                }
            } while (!validOptions.Contains(input));

            return input;
        }

        /// <summary>
        /// Gets a valid integer input within a specific range.
        /// </summary>
        /// <param name="ui">The user interface for interaction.</param>
        /// <param name="prompt">The message to display to the user.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>A valid integer input.</returns>
        public static int GetValidatedInteger(IUserInterface ui, string prompt, int min, int max)
        {
            int result;
            do
            {
                ui.Write($"{prompt} (Enter a number between {min} and {max}): ");

                if (int.TryParse(ui.ReadLine(), out result) && result >= min && result <= max)
                {
                    return result;
                }

                ui.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            } while (true);
        }

        /// <summary>
        /// Converts a short decision code into its full text representation.
        /// </summary>
        /// <param name="decision">The decision code ("A" for Attack, "R" for Retreat).</param>
        /// <returns>The full text of the decision.</returns>
        public static string FullTextOfDecision(string decision)
        {
            // Return the corresponding full text based on the decision code.
            return decision == "A" ? "Attack" : "Retreat";
        }
    }
}
