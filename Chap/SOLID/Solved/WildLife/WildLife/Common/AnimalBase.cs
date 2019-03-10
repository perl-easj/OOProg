using System;

namespace WildLife.Common
{
    public abstract class AnimalBase
    {
        private int _ageLimit;

        protected IWorld TheWorld { get; }

        protected AnimalBase(AnimalKind kind, AnimalGender gender, int ageLimit = 3)
        {
            TheWorld = World.Instance;
            Kind = kind;
            Gender = gender;

            _ageLimit = ageLimit;
            Age = 0;
        }

        public void Live(Action<AnimalBase> preAct, Action<AnimalBase> postAct)
        {
            while (!Dead)
            {
                preAct(this);
                Act();
                postAct(this);
                Age++;
            }
        }

        public abstract void Act();

        #region Properties for Animal state
        public AnimalKind Kind { get; }

        public AnimalGender Gender { get; }

        public int Age { get; private set; }

        public bool Dead
        {
            get { return Age >= _ageLimit; }
        }

        public bool Hungry
        {
            get { return Randomizer.CoinFlip(); }
        }

        public bool Sleepy
        {
            get { return Randomizer.CoinFlip(); }
        }
        #endregion

        #region Methods for Animal behaviors
        public void Sleep()
        {
            Console.WriteLine("Sleeping...");
        }

        public void Hunt()
        {
            Console.WriteLine("Hunting...");
        }

        public void Scavenge()
        {
            Console.WriteLine("Scavenging...");
        }

        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public void Mate()
        {
            Console.WriteLine("Mating...");
        }

        public void Flee()
        {
            Console.WriteLine("Fleeing...");
        }

        public void Idle()
        {
            Console.WriteLine("Idle...");
        }
        #endregion

        public override string ToString()
        {
            return $"A{(Dead ? "" : " not")} dead,{(Hungry ? "" : " not")} hungry,{(Sleepy ? "" : " not")} sleepy {Gender} {Kind}";
        }
    }
}