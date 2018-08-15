using PvPSimulator.Players;

namespace PvPSimulator.PlayerFactory
{
    /// <summary>
    /// Interface for a Factory class, which can produce 
    /// two IPlayer objects A and B, which can then be 
    /// used in a PvP battle simulation.
    /// </summary>
    public interface IPlayerFactory
    {
        IPlayer CreatePlayerA();
        IPlayer CreatePlayerB();
    }
}