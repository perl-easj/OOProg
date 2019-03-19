using System;

namespace SOLID.Liskov.Yes
{
    public class AnimalSizeLarge : AnimalBase, ILargeSizeAnimal
    {
        public AnimalSizeLarge(string description) : base(description)
        {
        }

        public sealed override double WeightInKg
        {
            get
            {
                return base.WeightInKg;
            }

            set
            {
                ValidateLargeWeight(value);
                base.WeightInKg = value;
            }
        }

        public void ValidateLargeWeight(double weight)
        {
            if (weight < 1)
            {
                throw new ArgumentException("Weight cannot be set to less than 1.0 kg for large animals");
            }
        }
    }
}