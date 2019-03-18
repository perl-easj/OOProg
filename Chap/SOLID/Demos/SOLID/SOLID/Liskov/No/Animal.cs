using System;
// ReSharper disable UnusedParameter.Local

namespace SOLID.Liskov.No
{
    public class Animal
    {
        private double _weightInKg;
        private Animal _isHuntedBy;
        private string _description;

        public Animal(string description, double weightInKg, Animal isHuntedBy = null)
        {
            SetWeight(WeightInKg);
            IsHuntedBy = isHuntedBy;
            Description = description;
        }

        public virtual double WeightInKg
        {
            get { return _weightInKg; }
        }

        public virtual Animal IsHuntedBy
        {
            get { return _isHuntedBy; }
            set { _isHuntedBy = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public virtual void SetWeight(double weight)
        {
            if (weight < 0.001)
            {
                throw new ArgumentException("Weight cannot be less than 0.001 kg");
            }

            _weightInKg = weight;
        }

        public override string ToString()
        {
            string huntedDesc = IsHuntedBy == null ? 
                "not hunted." : 
                $"hunted by a {IsHuntedBy.Description}";

            return $"{Description}, weighing {WeightInKg} kg., is {huntedDesc}";
        }
    }
}