using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Interfaces
{
    internal interface IRounds
    {
        void ExecuteRounds(IUserInterface ui, List<General> generals, IKing kingTrigger, IStatistics statisticsService);
    }
}
