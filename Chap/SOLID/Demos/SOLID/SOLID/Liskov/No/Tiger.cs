using System;

namespace SOLID.Liskov.No
{
    public class Tiger : Animal
    {
        public Tiger(double weightInKg) 
            : base("Tiger", weightInKg)
        {
        }

        public override Animal IsHuntedBy
        {
            get { return base.IsHuntedBy; }
            set
            {
                if (value != null)
                {
                    throw new ArgumentException("A Tiger is not hunted by anyone!");
                }

                base.IsHuntedBy = null;
            }
        }

        public override void SetWeight(double weight)
        {
            if (weight < 1)
            {
                throw new ArgumentException("Weight cannot be less than 1.0 kg for a Tiger");
            }

            base.SetWeight(weight);
        }
    }
}