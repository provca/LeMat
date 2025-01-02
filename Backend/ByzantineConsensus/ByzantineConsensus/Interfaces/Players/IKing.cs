using ByzantineConsensus.Models;

namespace ByzantineConsensus.Interfaces.Players
{
    public interface IKing
    {
        /// <summary>
        /// Gets or sets the decision of the king.
        /// </summary>
        string Decision { get; set; }

        /// <summary>
        /// Prompts the King to make an initial decision (whether to attack or retreat).
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <returns>A string representing the King's initial order: either "A" for attack or "R" for retreat.</returns>
        string GetInitialDecision(IUserInterface ui);

        /// <summary>
        /// Prompts the King to make an final decision (whether to attack or retreat).
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <returns>A string representing the King's initial order: either "A" for attack or "R" for retreat.</returns>
        string ChangeInitialDecision(IUserInterface ui);

        /// <summary>
        /// Executes a round of persuasion, where the King interacts with each general to influence their loyalty.
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <param name="generals">A list of generals involved in the game.</param>
        /// <param name="kingTrigger">The instance of the King responsible for the persuasion.</param>
        void ExecutePersuasionRound(IUserInterface ui, List<General> generals, IKing kingTrigger);

        /// <summary>
        /// Persuades a general based on the selected action. The King can try to neutralize differences, convert traitors, or turn loyals into traitors.
        /// </summary>
        /// <param name="ui">The user interface to display messages and interact with the user.</param>
        /// <param name="general">The general that the King is trying to persuade.</param>
        /// <param name="action">The action the King chooses to influence the general's loyalty.</param>
        void PersuadeGeneral(IUserInterface ui, IGeneral general, string action);
    }
}
