
namespace ChasingWindmillsInLogic.DonQuixote
{
    /// <summary>
    /// A class that represents a paradoxical logical construct inspired by Don Quixote.
    /// </summary>
    internal class DonQuixoteLogic
    {
        /// <summary>
        /// Evaluates a self-referential logical proposition in an infinite loop.
        /// </summary>
        /// <returns>
        /// A boolean value indicating the truth of the paradoxical proposition.
        /// </returns>
        /// <remarks>
        /// This method recursively calls itself with no base case, leading to a stack overflow.
        /// It demonstrates the futility of chasing unattainable logical consistency.
        /// </remarks>
        /// <exception cref="StackOverflowException">
        /// Always thrown due to infinite recursion.
        /// </exception>
        public static bool DonQuixote() => !DonQuixote();

        /// <summary>
        /// Evaluates a self-referential logical proposition with bounded recursion.
        /// </summary>
        /// <param name="depth">The current depth of recursion.</param>
        /// <returns>
        /// A boolean value indicating the truth of the paradoxical proposition.
        /// </returns>
        /// <remarks>
        /// This method is a bounded version of the infinite recursion. It stops after reaching
        /// a predefined maximum depth, throwing a <see cref="StackOverflowException"/> to simulate
        /// the collapse of recursive reasoning.
        /// </remarks>
        /// <exception cref="StackOverflowException">
        /// Thrown when the maximum recursion depth is reached.
        /// </exception>
        public static bool DonQuixote(int depth)
        {
            // Initial message when starting the recursion.
            if (depth == 0)
            {
                Console.WriteLine("Is the proposition true?");
            }

            // Maximum recursion depth allowed.
            const int maxDepth = 1000;

            // Checks if the recursion depth exceeds the limit.
            if (depth >= maxDepth)
            {
                throw new StackOverflowException("The madness was too much to bear!");
            }

            // Returns the negation of the next recursive call.
            return !DonQuixote(depth + 1);
        }
    }
}
