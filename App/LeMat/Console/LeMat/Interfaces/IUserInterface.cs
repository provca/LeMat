namespace LeMat.Interfaces
{
    /// <summary>
    /// Defines a user interface for interacting with input and output streams.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Writes a message to the user interface in a single line.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void Write(string message);

        /// <summary>
        /// Writes a message to the user interface.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void WriteLine(string message);

        /// <summary>
        /// Reads input from the user interface.
        /// </summary>
        /// <returns>The input entered by the user as a string.</returns>
        string ReadLine();

        /// <summary>
        /// Clears the console screen.
        /// Some clases colud configure the console colors by setting the foreground and background colors,
        /// for example in <see cref="LeMat.User.ConsoleUserInterface"/>.
        /// </summary>
        void Clear();
    }
}
