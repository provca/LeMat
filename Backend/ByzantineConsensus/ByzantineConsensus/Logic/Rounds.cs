using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Logic.Utilities;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Logic
{
    internal class Rounds : IRounds
    {
        public void ExecuteRounds(IUserInterface ui, List<General> generals, IKing kingTrigger, IStatistics statisticsService)
        {
            for (int round = 1; round <= 2; round++)
            {
                ui.WriteLine($"\nRound {round}:");
                kingTrigger.ExecutePersuasionRound(ui, generals, kingTrigger);

                ui.WriteLine("\nEnd of Round Statistics:");
                statisticsService.DisplayGeneralStatistics(generals, ui);

                if (round == 1)
                {
                    string prompt = "Do you want to proceed to the next round or stop and finalize? (continue/stop)";
                    string decision = InputHelper.GetValidatedInput(ui, prompt, new[] { "continue", "stop" });

                    if (decision == "stop")
                    {
                        ExecuteComplot(ui, generals);
                        break;
                    }
                }
            }
        }

        private static void ExecuteComplot(IUserInterface ui, List<General> generals)
        {
            ui.WriteLine("\nExecuting Complot Phase...");

            var traitors = generals.Where(g => !g.IsHonest && g.Respect > 0 && g.Respect <= 3).ToList();
            if (!traitors.Any())
            {
                ui.WriteLine("No traitors with sufficient influence for a complot.");
                return;
            }

            var vulnerableLoyals = generals.Where(g => g.IsHonest && g.Respect > 0 && g.Respect <= 3).ToList();
            foreach (var loyal in vulnerableLoyals)
            {
                if (traitors.Any(t => t.Respect > loyal.Respect))
                {
                    loyal.IsHonest = false;
                    ui.WriteLine($"{loyal.Name} was persuaded to become a traitor during the complot.");
                }
                else if (traitors.Any(t => t.Respect == loyal.Respect))
                {
                    ui.WriteLine($"{loyal.Name} prefers to support the king due to lack of allies.");
                }
            }
        }
    }
}
