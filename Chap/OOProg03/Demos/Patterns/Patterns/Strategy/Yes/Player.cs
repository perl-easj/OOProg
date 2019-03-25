using System;
using System.Collections.Generic;
using Patterns.Strategy.Yes.Interfaces;
using Patterns.Strategy.Yes.Types;

namespace Patterns.Strategy.Yes
{
    public class Player : IPlayer
    {
        private int _initialHP;
        private int _currentHP;

        private Dictionary<Affinity, IFight> _currentfightStrategies;
        private IFightFactory _fsFac;

        public string Name { get; }
        public Affinity CurrentAffinity { get; set; }
        
        public Player(string name, int hp, Affinity aff, IFightFactory fsFac)
        {
            _initialHP = hp;
            _fsFac = fsFac;

            Name = name;
            CurrentAffinity = aff;
            
            HP = hp;

            _currentfightStrategies = _fsFac.Create(CurrentTactics);
        }

        public FightTactic CurrentTactics
        {
            get { return (HP < (_initialHP / 2) ? FightTactic.defensive : FightTactic.offensive); }
        }

        public int HP
        {
            get { return _currentHP;}
            set
            {
                FightTactic currTactic = CurrentTactics;
                _currentHP = value;
                FightTactic newTactic = CurrentTactics;

                if (currTactic != newTactic)
                {
                    _currentfightStrategies = _fsFac.Create(newTactic);
                }
            }
        }

        public void DoCombat(IPlayer opponent)
        {
            if (_currentfightStrategies.ContainsKey(CurrentAffinity))
            {
                throw new Exception($"No fight strategy set for {CurrentAffinity} affinity");
            }

            _currentfightStrategies[CurrentAffinity].Fight(this, opponent);
        }
    }
}