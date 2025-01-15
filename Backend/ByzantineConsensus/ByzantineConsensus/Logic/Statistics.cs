using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Logic
{
    /// <summary>
    /// Provides methods for calculating and displaying game statistics.
    /// </summary>
    internal class Statistics : IStatistics
    {
        /// <inheritdoc />
        public (int Total, int Loyal, int Traitor) CalculateStatistics(List<General> generals) =>
            (generals.Count, generals.Count(g => g.IsHonest), generals.Count(g => !g.IsHonest));

        /// <inheritdoc />
        public void DisplayInitialStatistics(List<General> generals, IUserInterface ui)
        {
            var (total, loyal, traitor) = CalculateStatistics(generals);
            ui.WriteLine(
                $"Initial Statistics:\n" +
                $"Loyal: {loyal} ({(loyal * 100.0 / total):F2}%)\n" +
                $"Traitor: {traitor} ({(traitor * 100.0 / total):F2}%)\n"
            );
        }

        /// <inheritdoc />
        public void DisplayGeneralStatistics(List<General> generals, IUserInterface ui)
        {
            DisplayInitialStatistics(generals, ui);

            // Uncomment bucle to see the properties of each general.
            /*
            foreach (var general in generals)
            {
                ui.WriteLine($"{general.Name} - Loyalty: {(general.IsHonest ? "Loyal" : "Traitor")}, Respect: {general.Respect}");
            }
            */
        }

        /// <inheritdoc />
        public void DisplayFinalStatistics(List<General> generals, IUserInterface ui)
        {
            var (total, loyal, traitor) = CalculateStatistics(generals);
            ui.WriteLine(
                $"\nFinal Statistics:\n" +
                $"Loyal: {loyal} ({(loyal * 100.0 / total):F2}%)\n" +
                $"Traitor: {traitor} ({(traitor * 100.0 / total):F2}%)\n"
            );

            foreach (var general in generals)
            {
                ui.WriteLine($"{general.Name} - Loyalty: {(general.IsHonest ? "Loyal" : "Traitor")}, Respect: {general.Respect}");
            }
        }
    }
}
