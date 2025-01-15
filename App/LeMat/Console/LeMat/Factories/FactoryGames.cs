using LeMat.Adapters;
using LeMat.Games.ByzantineGenerals;
using LeMat.Games.DonQuixote;
using LeMat.Games.MontyHallProblem;
using LeMat.Games.SchroedingersCat;
using LeMat.Interfaces;
using LeMat.User;

namespace LeMat.Factories
{
    /// <summary>
    /// Factory class for selecting and running different games based on user input.
    /// </summary>
    internal class FactoryGames
    {
        /// <summary>
        /// Selects a game to run based on the provided option.
        /// </summary>
        /// <param name="option">The game option to select.</param>
        public static void SelectGame(int option)
        {
            switch (option)
            {
                case 0:
                    RunDonQuixote();
                    break;
                case 1:
                    RunMontyHallProblem();
                    break;
                case 2:
                    RunSchroedingersCat();
                    break;
                case 3:
                    RunByzantineGenerals();
                    break;
                default:
                    // No action for invalid option.
                    break;
            }
        }

        /// <summary>
        /// Creates an adapter for the LeMat console user interface.
        /// </summary>
        /// <returns>An instance of <see cref="IUserInterface"/>.</returns>
        private static IUserInterface CreateLeMatAdapter() => new ConsoleUserInterface();

        /// <summary>
        /// Creates an adapter for the ThreeDoors game user interface.
        /// </summary>
        /// <returns>An instance of <see cref="ThreeDoors.Interfaces.IUserInterface"/>.</returns>
        private static ThreeDoors.Interfaces.IUserInterface CreateThreeDoorsAdapter() => new ThreeDoorsAdapter(new ConsoleUserInterface());

        /// <summary>
        /// Creates an adapter for the QuantumCat game user interface.
        /// </summary>
        /// <returns>An instance of <see cref="QuantumCat.Interfaces.IUserInterface"/>.</returns>
        private static QuantumCat.Interfaces.IUserInterface CreateQuantumCatAdapter() => new QuantumCatAdapter(new ConsoleUserInterface());

        /// <summary>
        /// Creates an adapter for the ByzantineGenerals game user interface.
        /// </summary>
        /// <returns>An instance of <see cref="ByzantineConsensus.Interfaces.IUserInterface"/>.</returns>
        private static ByzantineConsensus.Interfaces.IUserInterface CreateByzantineGeneralsAdapter() => new ByzantineConsensusAdapter(new ConsoleUserInterface());

        /// <summary>
        /// Runs the Don Quixote game.
        /// </summary>
        private static void RunDonQuixote()
        {
            var adapter = CreateLeMatAdapter();
            DonQuixoteGame game = new(adapter);
            game.Initialize();
        }

        /// <summary>
        /// Runs the Monty Hall Problem game.
        /// </summary>
        private static void RunMontyHallProblem()
        {
            var adapter = CreateThreeDoorsAdapter();
            MontyHallProblemGame game = new(adapter);
            game.Initialize();
        }

        /// <summary>
        /// Runs the Schrödinger's Cat game.
        /// </summary>
        private static void RunSchroedingersCat()
        {
            var adapter = CreateQuantumCatAdapter();
            SchroedingersCatGame game = new(adapter);
            game.Initialize();
        }

        /// <summary>
        /// Runs the Byzantine Generals game.
        /// </summary>
        private static void RunByzantineGenerals()
        {
            var adapter = CreateByzantineGeneralsAdapter();
            ByzantineGeneralsGame game = new(adapter);
            game.Initialize();
        }
    }
}
