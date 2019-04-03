using System;
using System.Collections.Generic;
using Patterns.Strategy.Yes.Interfaces;
using Patterns.Strategy.Yes.Types;

namespace Patterns.Strategy.Yes
{
    public class FightFactoryImpl : IFightFactory
    {
        private Dictionary<FightTactic, Dictionary<Affinity, IFight>> _strategies;

        public FightFactoryImpl()
        {
            _strategies = new Dictionary<FightTactic, Dictionary<Affinity, IFight>>();
        }

        public void AddStrategy(Affinity aff, FightTactic tactics, IFight fightStrat)
        {
            if (!_strategies.ContainsKey(tactics))
            {
                _strategies[tactics] = new Dictionary<Affinity, IFight>();
            }

            _strategies[tactics][aff] = fightStrat;
        }

        public Dictionary<Affinity, IFight> Create(FightTactic tactic)
        {
            if (!_strategies.ContainsKey(tactic))
            {
                throw new Exception($"No fight strategy set for {tactic} tactics");
            }

            return _strategies[tactic];
        }
    }
}