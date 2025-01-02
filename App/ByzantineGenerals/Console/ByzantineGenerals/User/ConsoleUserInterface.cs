using ByzantineConsensus.Interfaces;

namespace ByzantineGenerals.User
{
    /// <summary>
    /// Provides a console-based implementation of the <see cref="IUserInterface"/>.
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        /// <inheritdoc />
        public void Write(string message) => Console.Write(message);

        /// <inheritdoc />
        public void WriteLine(string message) => Console.WriteLine(message);

        /// <inheritdoc />
        public string ReadLine() => Console.ReadLine() ?? string.Empty;

        /// <inheritdoc />
        public void Clear() => Console.Clear();
    }
}
