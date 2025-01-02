using ByzantineConsensus.Interfaces;

namespace ByzantineConsensus.Logic.Utilities
{
    public class InputHelper
    {
        public static string GetValidatedInput(IUserInterface ui, string prompt, string[] validOptions)
        {
            string input;
            do
            {
                ui.WriteLine(prompt);
                input = ui.ReadLine()?.ToLower() ?? string.Empty;
                if (!validOptions.Contains(input))
                {
                    ui.WriteLine($"Invalid option. Please choose one of the following: {string.Join(", ", validOptions)}.");
                }
            } while (!validOptions.Contains(input));

            return input;
        }
    }
}
