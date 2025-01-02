using ByzantineConsensus.Models;

namespace ByzantineConsensus.Interfaces.Players
{
    public interface IKing
    {
        string GetInitialDecision(IUserInterface ui);
        void ExecutePersuasionRound(IUserInterface ui, List<General> generals, IKing kingTrigger);
        void PersuadeGeneral(IUserInterface ui, IGeneral general, string action);
    }
}
