using Patterns.Strategy.No.Interfaces;
using Patterns.Strategy.No.Types;
using Patterns.Strategy.No.Strategies;

namespace Patterns.Strategy.No
{
    public class Player : IPlayer
    {
        private int _initialHP;
        private int _currentHP;

        private IFight _sunDefStrat;
        private IFight _sunOffStrat;
        private IFight _moonDefStrat;
        private IFight _moonOffStrat;
        private IFight _starsDefStrat;
        private IFight _starsOffStrat;

        public string Name { get; }
        public Affinity CurrentAffinity { get; set; }

        public Player(string name, int hp, Affinity aff)
        {
            _initialHP = hp;
            Name = name;
            CurrentAffinity = aff;
            HP = hp;

            _sunDefStrat = new SunFightDefensive();
            _sunOffStrat = new SunFightOffensive();
            _moonDefStrat = new MoonFightDefensive();
            _moonOffStrat = new MoonFightOffensive();
            _starsDefStrat = new StarsFightDefensive();
            _starsOffStrat = new StarsFightOffensive();
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
            if (CurrentAffinity == Affinity.sun && CurrentTactics == FightTactic.defensive)
            {
                _sunDefStrat.Fight(this, opponent);
            }

            // And so on...
        }
    }
}