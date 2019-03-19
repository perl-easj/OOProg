using System;

namespace SOLID.Liskov.Yes
{
    public class AnimalSizeNormal : AnimalBase, INormalSizeAnimal
    {
        public AnimalSizeNormal(string description) : base(description)
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
                ValidateNormalWeight(value);
                base.WeightInKg = value;
            }
        }

        public void ValidateNormalWeight(double weight)
        {
            if (weight < 0.001)
            {
                throw new ArgumentException("Weight cannot be set to less than 0.001 kg for normal animals");
            }
        }
    }
}