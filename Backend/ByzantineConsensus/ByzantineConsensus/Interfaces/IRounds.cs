using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Interfaces
{
    internal interface IRounds
    {
        /// <summary>
        /// Executes two main rounds of interaction, where the king interacts with generals and tries to influence their loyalty.
        /// After each round, statistics are displayed. After the first round, the king is prompted to either continue or stop.
        /// If stopped, the complot phase is executed.
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <param name="generals">A list of generals participating in the game.</param>
        /// <param name="kingTrigger">The instance of the king that executes the persuasion rounds.</param>
        /// <param name="statisticsService">The service responsible for displaying general statistics during the rounds.</param>
        void ExecuteRounds(IUserInterface ui, List<General> generals, IKing kingTrigger, IStatistics statisticsService);
    }
}
