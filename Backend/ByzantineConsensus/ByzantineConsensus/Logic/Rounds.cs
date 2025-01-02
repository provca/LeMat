using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Logic.Utilities;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Logic
{
    /// <summary>
    /// Handles the execution of game rounds, including persuasion and complot phases.
    /// </summary>
    internal class Rounds : IRounds
    {
        /// <inheritdoc />
        public void ExecuteRounds(IUserInterface ui, List<General> generals, IKing kingTrigger, IStatistics statisticsService)
        {
            for (int round = 1; round <= 2; round++)
            {
                ui.Clear();
                ui.WriteLine($"Round {round}:");
                kingTrigger.ExecutePersuasionRound(ui, generals, kingTrigger);

                // Display statistics at the end of the round.
                ui.Clear();
                ui.WriteLine("\nEnd of Round Statistics:");
                statisticsService.DisplayGeneralStatistics(generals, ui);

                if (round == 1)
                {
                    // Prompt the King to continue or stop after the first round.
                    string prompt = "Do you want to proceed to the next round or stop and finalize? (continue (C)/stop (S))";
                    string decision = InputHelper.GetValidatedInput(ui, prompt, new[] { "C", "S" });

                    if (decision == "S")
                    {
                        ExecuteComplot(ui, generals);
                        break;
                    }
                }
            }

            // Evaluate the final decision.
            EvaluateFinalDecision(ui, generals, kingTrigger, statisticsService);
        }

        /// <summary>
        /// Evaluates the final decision of the King based on the loyalty of the generals and the King's decisions.
        /// </summary>
        /// <param name="ui">The user interface to interact with the player.</param>
        /// <param name="generals">The list of generals whose loyalty is analyzed.</param>
        /// <param name="kingTrigger">The King, whose decisions are being evaluated.</param>
        /// <param name="statisticsService">The service to calculate loyalty and traitor statistics.</param>
        private static void EvaluateFinalDecision(IUserInterface ui, List<General> generals, IKing kingTrigger, IStatistics statisticsService)
        {
            // Retrieve the initial decision made by the King.
            string initialDecision = kingTrigger.Decision;

            // Allow the King to change their initial decision, if desired.
            string finalDecision = kingTrigger.ChangeInitialDecision(ui);

            // Calculate the number of loyal and traitor generals.
            var (total, loyal, traitor) = statisticsService.CalculateStatistics(generals);

            // Check the outcome based on the loyalty and traitor counts.
            if (loyal == traitor)
            {
                // If the number of loyal and traitor generals is equal, it's a tie.
                ui.WriteLine("Result: It's a tie. No clear winner emerges.");
            }
            else if (loyal > traitor)
            {
                // If loyal generals are the majority, the King wins regardless of decision changes.
                ui.WriteLine("Result: You won! The majority are loyal, and they will follow your orders.");
            }
            else
            {
                // If traitors are the majority, determine the outcome based on decision alignment.
                bool decisionChanged = !string.Equals(initialDecision, finalDecision, StringComparison.OrdinalIgnoreCase);

                if (!decisionChanged)
                {
                    // The King loses if they stick with their initial decision, misaligning with the majority.
                    ui.WriteLine("Result: You lost. Your decision didn't align with the majority (traitors).");
                }
                else
                {
                    // The King wins if they adapt and change their decision to align with the majority.
                    ui.WriteLine("Result: You won! Changing your decision has made the traitors align with you.");
                }
            }
        }

        /// <summary>
        /// Executes the complot phase, where traitors attempt to influence loyal generals.
        /// </summary>
        /// <param name="ui">The user interface for displaying results.</param>
        /// <param name="generals">The list of generals involved in the complot.</param>
        private static void ExecuteComplot(IUserInterface ui, List<General> generals)
        {
            ui.Clear();
            ui.WriteLine("Executing Complot Phase...");

            // Identify traitors and vulnerable loyals.
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
                    // Convert a loyal to a traitor.
                    loyal.IsHonest = false;
                    ui.WriteLine($"{loyal.Name} was persuaded to become a traitor during the complot.");
                }
                else if (traitors.Any(t => t.Respect == loyal.Respect))
                {
                    ui.WriteLine($"{loyal.Name} resisted persuasion and remains loyal.");
                }
            }
        }
    }
}
