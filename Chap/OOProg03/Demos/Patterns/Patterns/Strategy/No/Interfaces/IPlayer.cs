using Patterns.Strategy.No.Types;

namespace Patterns.Strategy.No.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        int HP { get; set; }
        Affinity CurrentAffinity { get; set; }
        FightTactic CurrentTactics { get; }
        void DoCombat(IPlayer opponent);
    }
}