namespace ByzantineConsensus.Logic.Utilities
{
    internal class RandomHelper
    {
        private static readonly Random _random = new();

        public static bool NextBool() => _random.Next(0, 2) == 0;
    }
}
