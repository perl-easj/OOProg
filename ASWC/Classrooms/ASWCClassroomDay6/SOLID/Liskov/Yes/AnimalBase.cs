using System;

namespace SOLID.Liskov.Yes
{
    public abstract class AnimalBase : IAnimal
    {
        private const double weightUndefined = -1;

        private string _description;
        protected double _weightInKg;

        protected AnimalBase(string description)
        {
            Description = description;
            _weightInKg = weightUndefined;
        }

        public virtual double WeightInKg
        {
            get
            {
                if (_weightInKg < 0)
                {
                    throw new Exception("Weight has not been set");
                }
                return _weightInKg;
            }

            set { _weightInKg = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public override string ToString()
        {
            return $"{Description}, , weighing {WeightInKg} kg.";
        }
    }
}