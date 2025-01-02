using ByzantineConsensus.Interfaces;
using ByzantineConsensus.Logic.Utilities;
using ByzantineConsensus.Models;

namespace ByzantineConsensus.Factories
{
    public class GameFactory
    {
        public Game.Game CreateGame(IUserInterface ui, int numOfGenerals)
        {
            var generals = CreateGenerals(numOfGenerals);
            var king = new King();
            return new Game.Game(ui, generals, king);
        }

        private List<General> CreateGenerals(int count)
        {
            List<General> generals = new();
            for (int i = 0; i < count; i++)
            {
                bool isHonest = RandomHelper.NextBool();
                int respect = isHonest ? General.LoyalInitialRespect : General.TraitorInitialRespect;
                generals.Add(new General($"General {Convert.ToChar('A' + i)}", isHonest, respect));
            }
            return generals;
        }
    }
}
