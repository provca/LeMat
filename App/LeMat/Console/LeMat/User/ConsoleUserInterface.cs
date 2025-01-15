using LeMat.Interfaces;
using LeMat.Utilities;

namespace LeMat.User
{
    /// <summary>
    /// Provides a console-based implementation of the <see cref="IUserInterface"/>.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <inheritdoc />
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <inheritdoc />
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc />
        public string ReadLine()
        {
            // Ensures that null input is handled safely by returning an empty string instead.
            return Console.ReadLine() ?? string.Empty;
        }

        /// <inheritdoc />
        public void Clear()
        {
            Utilities_Console.ConsoleMainColors();
        }
    }
}

