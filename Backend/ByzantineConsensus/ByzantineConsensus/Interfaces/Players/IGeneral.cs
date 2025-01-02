namespace ByzantineConsensus.Interfaces.Players
{
    public interface IGeneral
    {
        string Name { get; }
        int Respect { get; set; }
        bool IsHonest { get; set; }
        string ReceivedOrder { get; set; }
        void ChangeLoyalty(bool newHonesty, int respectChange);
    }
}
