namespace ByzantineConsensus.Interfaces.Players
{
    /// <summary>
    /// Defines the properties and methods for a general in the Byzantine Generals' Problem.
    /// </summary>
    public interface IGeneral
    {
        /// <summary>
        /// Gets the name of the general.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the respect level of the general.
        /// </summary>
        int Respect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the general is honest or a traitor.
        /// </summary>
        bool IsHonest { get; set; }

        /// <summary>
        /// Gets or sets the order received by the general.
        /// </summary>
        string ReceivedOrder { get; set; }

        /// <summary>
        /// Changes the loyalty of the general and adjusts their respect level.
        /// </summary>
        /// <param name="newHonesty">The new honesty state of the general.</param>
        /// <param name="respectChange">The amount to change the respect level.</param>
        void ChangeLoyalty(bool newHonesty, int respectChange);
    }
}
