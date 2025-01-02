using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Logic.Utilities;

namespace ByzantineConsensus.Models
{
    public class King : IKing
    {
        public string GetInitialDecision(IUserInterface ui)
        {
            string prompt = "\nWhat is your initial order? (attack/retreat)";
            return InputHelper.GetValidatedInput(ui, prompt, new[] { "attack", "retreat" });
        }

        public void ExecutePersuasionRound(IUserInterface ui, List<General> generals, IKing kingTrigger)
        {
            foreach (IGeneral general in generals.Cast<IGeneral>())
            {
                ui.WriteLine($"\nInteracting with {general.Name}...");
                ui.WriteLine(
                    "Choose an action:\n" +
                    "1. Neutral (No changes)\n" + // Neutral
                    "2. Attempt to influence loyalty\n" + // Try to convert traitors to loyals
                    "3. Strong appeal to loyalty" // loyals become traitors
                    );

                string action = ui.ReadLine().ToLower();
                kingTrigger.PersuadeGeneral(ui, general, action);
            }
        }

        public void PersuadeGeneral(IUserInterface ui, IGeneral general, string action)
        {
            switch (action)
            {
                case "1":
                    ui.WriteLine($"{general.Name}: \"You are a great strategist, but my decision remains unchanged.\"");
                    break;
                case "2":
                    HandlePartialInfluence(ui, general);
                    break;
                case "3":
                    HandleStrongInfluence(ui, general);
                    break;
                default:
                    ui.WriteLine($"{general.Name}: \"I don't understand what you're trying to tell me.\"");
                    break;
            }
        }

        private static void HandlePartialInfluence(IUserInterface ui, IGeneral general)
        {
            if (general.IsHonest)
            {
                bool turnedTraitor = RandomHelper.NextBool();
                general.ChangeLoyalty(!turnedTraitor, turnedTraitor ? -1 : -2);
                ui.WriteLine($"{general.Name}: \"Thank you for the promise. My decision remains unchanged.\"");
            }
            else
            {
                ui.WriteLine($"{general.Name}: \"I accept your lands, but my loyalty remains... flexible.\"");
            }
        }

        private static void HandleStrongInfluence(IUserInterface ui, IGeneral general)
        {
            if (!general.IsHonest)
            {
                general.ChangeLoyalty(true, 1);
                ui.WriteLine($"{general.Name}: \"I accept your lands, but my loyalty remains... flexible.\"");
            }
            else
            {
                general.ChangeLoyalty(true, 2);
                ui.WriteLine($"{general.Name}: \"I trust your leadership. I will remain loyal.\"");
            }
        }
    }
}
