using Patterns.Strategy.Yes.Types;

namespace Patterns.Strategy.Yes.Interfaces
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