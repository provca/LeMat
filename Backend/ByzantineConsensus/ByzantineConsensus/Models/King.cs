using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Logic.Utilities;

namespace ByzantineConsensus.Models
{
    /// <summary>
    /// Represents the King in the Byzantine Generals' Problem, responsible for making decisions and persuading generals.
    /// </summary>
    public class King : IKing
    {
        /// <inheritdoc />
        public string Decision { get; set; } = string.Empty;

        /// <inheritdoc />
        public string GetInitialDecision(IUserInterface ui)
        {
            // Prompt the King for the initial decision (attack or retreat).
            string prompt = "What is your initial order? attack (A)/retreat (R)";
            Decision = prompt;
            return InputHelper.GetValidatedInput(ui, prompt, new[] { "A", "R" });
        }

        /// <inheritdoc />
        public string ChangeInitialDecision(IUserInterface ui)
        {
            // Prompt the King for the final decision (attack or retreat).
            string prompt = "What is your final order? (attack (A)/retreat (R))";
            string input = InputHelper.GetValidatedInput(ui, prompt, new[] { "A", "R" });

            if (!string.IsNullOrEmpty(input))
            {
                Decision = input;
            }

            return Decision;
        }

        /// <inheritdoc />
        public void ExecutePersuasionRound(IUserInterface ui, List<General> generals, IKing kingTrigger)
        {
            // Iterate over each general and allow the King to interact with them.
            foreach (IGeneral general in generals.Cast<IGeneral>())
            {
                ui.Clear();
                ui.WriteLine($"Interacting with {general.Name}...");
                ui.WriteLine(
                    "1. War is not won solely on the battlefield, but also in the hearts of men.\n" +
                    "2. The art of governance is balancing mercy with severity.\n" +
                    "3. The Byzantine Empire never died; it merely changed form."
                );

                // Get validated user input for action selection.
                int action = InputHelper.GetValidatedInteger(ui, "   Select an action", 1, 3);

                // Map the selected action to a string command.
                string actionCommand = action switch
                {
                    1 => "1",
                    2 => "2",
                    3 => "3",
                    _ => string.Empty
                };

                // Pass the action to the King's PersuadeGeneral method.
                kingTrigger.PersuadeGeneral(ui, general, actionCommand);
            }
        }

        /// <inheritdoc />
        public void PersuadeGeneral(IUserInterface ui, IGeneral general, string action)
        {
            switch (action)
            {
                case "1":
                    // Neutral influence on the general.
                    ui.WriteLine($"{general.Name}: \"Nations are governed not only by the sword, but also by law and faith.\"");
                    break;
                case "2":
                    // Attempt to convert a traitor to loyal.
                    HandlePartialInfluence(ui, general);
                    break;
                case "3":
                    // Loyals become traitors.
                    HandleStrongInfluence(ui, general);
                    break;
                default:
                    ui.WriteLine($"{general.Name}: \"I don't understand your command.\"");
                    break;
            }
        }

        /// <summary>
        /// Handles the partial influence of the King on a general. This method tries to convert a loyal general into a traitor with a certain probability.
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <param name="general">The general whose loyalty is being influenced.</param>
        private static void HandlePartialInfluence(IUserInterface ui, IGeneral general)
        {
            if (general.IsHonest)
            {
                // Attempt to maintain loyalty but reduce respect.
                bool turnedTraitor = RandomHelper.NextBool();
                general.ChangeLoyalty(!turnedTraitor, turnedTraitor ? -1 : -2);
                ui.WriteLine($"{general.Name}: \"I would rather see a Turkish turban in Constantinople than a Latin mitre.\"");
            }
            else
            {
                // Traitor remains a traitor.
                ui.WriteLine($"{general.Name}: \"If the emperor cannot defend his city, then let him at least die with honor.\"");
            }
        }

        /// <summary>
        /// Handles the strong influence of the King on a general. This method tries to convert a traitor into a loyal general or strengthen a loyal general's respect.
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <param name="general">The general whose loyalty is being influenced.</param>
        private static void HandleStrongInfluence(IUserInterface ui, IGeneral general)
        {
            if (!general.IsHonest)
            {
                // Traitor becomes loyal.
                general.ChangeLoyalty(true, 1);
                ui.WriteLine($"{general.Name}: \"A king who destroys his country is not a king, but an executioner.\"");
            }
            else
            {
                // Loyal general's respect increases.
                general.ChangeLoyalty(true, 2);
                ui.WriteLine($"{general.Name}: \"Better an hour of free life than forty years of slavery and imprisonment.\"");
            }
        }

    }
}
