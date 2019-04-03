using System;
using System.Collections.Generic;
using Patterns.Strategy.No.Types;
using Patterns.Strategy.No.Interfaces;

namespace Patterns.Strategy.No
{
    public class Player3 : IPlayer
    {
        private int _initialHP;
        private int _currentHP;
        private Dictionary<Tuple<Affinity, FightTactic>, IFight> _strategies;

        public string Name { get; }
        public Affinity CurrentAffinity { get; set; }

            public Player3(string name, int hp, Affinity aff,
                Dictionary<Tuple<Affinity, FightTactic>, IFight> strategies)
            {
                _strategies = new Dictionary<Tuple<Affinity, FightTactic>, IFight>();

                _initialHP = hp;
                Name = name;
                CurrentAffinity = aff;
                HP = hp;
            }

        public FightTactic CurrentTactics
        {
            get { return (HP < (_initialHP / 2) ? FightTactic.defensive : FightTactic.offensive); }
        }

        public int HP
        {
            get { return _currentHP; }
            set { _currentHP = value; }
        }

        public void DoCombat(IPlayer opponent)
        {
            Tuple<Affinity, FightTactic> key = new Tuple<Affinity, FightTactic>(
                CurrentAffinity, CurrentTactics);

            if (_strategies.ContainsKey(key))
            {
                throw new Exception($"No strategi available for {CurrentAffinity}/{CurrentTactics}");
            }

            _strategies[key].Fight(this, opponent);
            // And so on...
        }
    }
}