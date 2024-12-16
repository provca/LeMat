using ThreeDoors.Interfaces;

namespace ThreeDoors.Logic
{
    /// <summary>
    /// Manages the statistical tracking of game results for the Three Doors problem.
    /// </summary>
    public class StatisticsManager
    {
        private int _totalRounds;
        private int _winsBySwitching;
        private int _winsBySticking;

        /// <summary>
        /// Records the result of a game round.
        /// </summary>
        /// <param name="switched">Indicates if the player switched doors.</param>
        /// <param name="won">Indicates if the player won the round.</param>
        public void RecordResult(bool switched, bool won)
        {
            // Increment the total rounds played.
            _totalRounds++;

            if (won)
            {
                // Increment the corresponding win counter based on the player's decision.
                if (switched)
                    _winsBySwitching++;
                else
                    _winsBySticking++;
            }
        }

        /// <summary>
        /// Displays the game statistics to the user.
        /// </summary>
        /// <param name="ui">The user interface to use for displaying the statistics.</param>
        public void DisplayStatistics(IUserInterface ui)
        {
            // Output the statistics to the user interface.
            ui.WriteLine("Statistics:");
            ui.WriteLine($"Rounds played: {_totalRounds}");
            ui.WriteLine($"Wins by switching doors: {_winsBySwitching} ({(double)_winsBySwitching / _totalRounds:P})");
            ui.WriteLine($"Wins by staying with the initial door: {_winsBySticking} ({(double)_winsBySticking / _totalRounds:P})");
        }
    }
}
