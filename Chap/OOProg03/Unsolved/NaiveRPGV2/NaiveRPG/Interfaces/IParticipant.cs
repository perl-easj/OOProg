using System.Collections.Generic;

namespace NaiveRPG.Interfaces
{
    /// <summary>
    /// Interface for game participants.
    /// </summary>
    public interface IParticipant
    {
        string Name { get; }
        double HealthPoints { get; }
        bool Dead { get; }
        int GoldOwned { get; set; }
        List<IItem> ItemsOwned { get; }
        double DealDamage();
        void ReceiveDamage(double damagePoints);
    }
}