using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Logic
{
    internal class Statistics : IStatistics
    {
        public (int Total, int Loyal, int Traitor) CalculateStatistics(List<General> generals) =>
            (generals.Count, generals.Count(g => g.IsHonest), generals.Count(g => !g.IsHonest));

        public void DisplayInitialStatistics(List<General> generals, IUserInterface ui)
        {
            var (totalGenerals, loyalGenerals, traitorGenerals) = CalculateStatistics(generals);
            ui.WriteLine(
                $"Initial Statistics:\n" +
                $"Loyal Generals: {loyalGenerals} ({(loyalGenerals * 100.0 / totalGenerals):F2}%)\n" +
                $"Traitor Generals: {traitorGenerals} ({(traitorGenerals * 100.0 / totalGenerals):F2}%)\n"
                );
        }

        public void DisplayGeneralStatistics(List<General> generals, IUserInterface ui)
        {
            foreach (var general in generals)
            {
                ui.WriteLine(
                    $"{general.Name} - Loyalty: {(general.IsHonest
                    ? "Loyal"
                    : "Traitor")}, Respect: {general.Respect}");
            }
        }

        public void DisplayFinalStatistics(List<General> generals, IUserInterface ui)
        {
            var (totalGenerals, loyalGenerals, traitorGenerals) = CalculateStatistics(generals);
            ui.WriteLine(
                $"\nFinal Statistics:\n" +
                $"Loyal Generals: {loyalGenerals} ({(loyalGenerals * 100.0 / totalGenerals):F2}%)\n" +
                $"Traitor Generals: {traitorGenerals} ({(traitorGenerals * 100.0 / totalGenerals):F2}%)\n"
                );

            DisplayGeneralStatistics(generals, ui);
        }
    }
}
