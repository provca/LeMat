using ByzantineConsensus.Models;

namespace ByzantineConsensus.Interfaces
{
    internal interface IStatistics
    {
        (int Total, int Loyal, int Traitor) CalculateStatistics(List<General> generals);
        void DisplayInitialStatistics(List<General> generals, IUserInterface ui);
        void DisplayFinalStatistics(List<General> generals, IUserInterface ui);
        void DisplayGeneralStatistics(List<General> generals, IUserInterface ui);
    }
}
