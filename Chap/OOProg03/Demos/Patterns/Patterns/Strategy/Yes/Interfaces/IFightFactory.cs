using System.Collections.Generic;
using Patterns.Strategy.Yes.Types;

namespace Patterns.Strategy.Yes.Interfaces
{
    public interface IFightFactory
    {
        Dictionary<Affinity, IFight> Create(FightTactic tactic);
    }
}