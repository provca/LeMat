using ByzantineConsensus.Models;

namespace ByzantineConsensus.Interfaces
{
    internal interface IStatistics
    {
        /// <summary>
        /// Calculates the statistics of the generals.
        /// </summary>
        /// <param name="generals">The list of generals.</param>
        /// <returns>The total, loyal, and traitor counts.</returns>
        (int Total, int Loyal, int Traitor) CalculateStatistics(List<General> generals);

        /// <summary>
        /// Displays the initial statistics of the generals, including the count of loyal and traitor generals,
        /// along with their percentages in relation to the total number of generals.
        /// </summary>
        /// <param name="generals">A list of generals in the game.</param>
        /// <param name="ui">The user interface for displaying the statistics to the user.</param>
        void DisplayInitialStatistics(List<General> generals, IUserInterface ui);

        /// <summary>
        /// Displays the loyalty and respect of each general in the game, including whether they are loyal or traitors.
        /// </summary>
        /// <param name="generals">A list of generals in the game.</param>
        /// <param name="ui">The user interface for displaying the statistics to the user.</param>
        void DisplayFinalStatistics(List<General> generals, IUserInterface ui);

        /// <summary>
        /// Displays the final statistics of the generals, including the count of loyal and traitor generals,
        /// along with their percentages in relation to the total number of generals. Also displays individual statistics for each general.
        /// </summary>
        /// <param name="generals">A list of generals in the game.</param>
        /// <param name="ui">The user interface for displaying the statistics to the user.</param>
        void DisplayGeneralStatistics(List<General> generals, IUserInterface ui);
    }
}
