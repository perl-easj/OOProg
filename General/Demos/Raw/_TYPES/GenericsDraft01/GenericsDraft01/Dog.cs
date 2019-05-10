using System;

namespace GenericsDraft01
{
    public class Dog : Animal, IComparable<Dog>
    {
        public Dog(string name, double weight) : base(name, weight)
        {
        }

        public override string Sound()
        {
            return "Vuff";
        }

        public int CompareTo(Dog other)
        {
            if (Weight > other.Weight)
            {
                return 1;
            }

            if (Weight < other.Weight)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return Name + "weighs " + Weight + " kgs.";
        }
    }
}