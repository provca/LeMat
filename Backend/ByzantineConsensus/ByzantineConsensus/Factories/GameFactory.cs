using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Logic.Utilities;
using ByzantineConsensus.Models;
using ByzantineConsensus.Play;

namespace ByzantineConsensus.Factories
{
    /// <summary>
    /// Factory for creating instances of the <see cref="Game"/> class and its required components.
    /// </summary>
    public class GameFactory
    {
        /// <summary>
        /// Creates a new game instance with the specified user interface and number of generals.
        /// </summary>
        /// <param name="ui">The user interface for the game.</param>
        /// <param name="numOfGenerals">The number of generals to be created for the simulation.</param>
        /// <returns>A fully initialized <see cref="Game"/> instance.</returns>
        public Game CreateGame(IUserInterface ui, int numOfGenerals)
        {
            // Create a list of generals based on the specified count.
            var generals = CreateGenerals(numOfGenerals);

            // Return a new Game instance with the UI and list of generals.
            return new Game(ui, generals);
        }

        /// <summary>
        /// Creates a list of generals with randomized loyalty and respect values.
        /// </summary>
        /// <param name="count">The number of generals to create.</param>
        /// <returns>A list of <see cref="General"/> instances.</returns>
        private static List<General> CreateGenerals(int count)
        {
            List<General> generals = new();

            // Loop to create each general.
            for (int i = 0; i < count; i++)
            {
                // Randomly determine if the general is honest or a traitor.
                bool isHonest = RandomHelper.NextBool();

                // Assign initial respect values based on loyalty.
                int respect = isHonest ? General.LoyalInitialRespect : General.TraitorInitialRespect;

                // Add the general to the list with a unique name.
                generals.Add(new General($"General {Convert.ToChar('A' + i)}", isHonest, respect));
            }

            return generals;
        }
    }
}
