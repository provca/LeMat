using ByzantineConsensus.Interfaces.Players;

namespace ByzantineConsensus.Models
{
    public class General(string name, bool isHonest, int respect) : IGeneral
    {
        public const int LoyalInitialRespect = 3;
        public const int TraitorInitialRespect = 2;

        /// <inheritdoc />
        public string Name { get; } = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Name cannot be null or empty.", nameof(name))
            : name;

        /// <inheritdoc />
        public int Respect { get; set; } = respect;

        /// <inheritdoc />
        public bool IsHonest { get; set; } = isHonest;

        /// <inheritdoc />
        public string ReceivedOrder { get; set; } = string.Empty;

        /// <inheritdoc />
        public void ChangeLoyalty(bool newHonesty, int respectChange)
        {
            IsHonest = newHonesty;
            Respect = Math.Max(0, Respect + respectChange);
        }
    }
}
