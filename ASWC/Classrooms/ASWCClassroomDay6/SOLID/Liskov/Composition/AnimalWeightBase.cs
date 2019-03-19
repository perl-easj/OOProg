using System;
// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace SOLID.Liskov.Composition
{
    public class AnimalWeightBase : IAnimalWeight
    {
        protected const double weightUndefined = -1;
        protected double _weightInKg;
        protected double _limitWeight;

        public AnimalWeightBase(double limitWeight)
        {
            _weightInKg = weightUndefined;
            _limitWeight = limitWeight;
        }

        public AnimalWeightBase(double limitWeight, double weight)
        {
            _limitWeight = limitWeight;
            WeightInKg = weight;
        }

        public double WeightInKg
        {
            get
            {
                if (_weightInKg < 0)
                {
                    throw new Exception("Weight has not been set");
                }
                return _weightInKg;
            }

            set
            {
                ValidateWeight(value);
                _weightInKg = value;
            }
        }

        private void ValidateWeight(double weight)
        {
            if (weight < _limitWeight)
            {
                throw new ArgumentException($"Weight cannot be set to less than {_limitWeight} kg for this animal");
            }
        }
    }
}