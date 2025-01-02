using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Interfaces.Players;
using ByzantineConsensus.Logic;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Game
{
    public class Game
    {
        private readonly IUserInterface _ui;
        private readonly List<General> _listOfGenerals;
        private readonly IKing _king;
        private readonly IRounds _rounds;
        private readonly IStatistics _statistics;

        public Game(IUserInterface ui, List<General> generals, King king)
        {
            _ui = ui;
            _listOfGenerals = generals;
            _king = new King();
            _rounds = new Rounds();
            _statistics = new Statistics();
        }

        public void Initialize()
        {
            DisplayInitialStatistics();

            _ui.WriteLine("Welcome to the Byzantine Generals' Council.");
            _ui.WriteLine("You are the King. Decide whether to attack or retreat.");
            _ui.WriteLine("Beware: some generals may be traitors!");

            string initialDecision = _king.GetInitialDecision(_ui);

            foreach (var general in _listOfGenerals)
                general.ReceivedOrder = initialDecision;

            ExecuteRounds();

            DisplayFinalStatistics();
        }

        private void DisplayInitialStatistics() =>
            _statistics.DisplayInitialStatistics(_listOfGenerals, _ui);

        private void DisplayFinalStatistics() =>
            _statistics.DisplayFinalStatistics(_listOfGenerals, _ui);

        private void ExecuteRounds() =>
            _rounds.ExecuteRounds(_ui, _listOfGenerals, _king, _statistics);
    }
}
