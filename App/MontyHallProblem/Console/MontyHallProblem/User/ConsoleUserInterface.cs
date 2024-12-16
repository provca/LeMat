using ThreeDoors.Interfaces;

namespace MontyHallProblem.User
{
    /// <summary>
    /// Provides a console-based implementation of the <see cref="IUserInterface"/>.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads a line of input from the console.
        /// </summary>
        /// <returns>
        /// The input entered by the user, or an empty string if the input is null.
        /// </returns>
        public string ReadLine()
        {
            // Ensures that null input is handled safely by returning an empty string instead.
            return Console.ReadLine() ?? string.Empty;
        }
    }
}

