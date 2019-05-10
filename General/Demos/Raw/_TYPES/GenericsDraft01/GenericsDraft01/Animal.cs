using System;

namespace GenericsDraft01
{
    public class Animal //: IComparable<Animal>
    {
        private string _name;
        private double _weight;

        protected Animal(string name, double weight)
        {
            _name = name;
            _weight = weight;
        }

        public string Name
        {
            get { return _name; }
        }

        public double Weight
        {
            get { return _weight; }
        }

        public virtual string Sound()
        {
            return "(none)";
        }

        //public int CompareTo(Animal other)
        //{
        //    if (Weight > other.Weight)
        //    {
        //        return 1;
        //    }

        //    if (Weight < other.Weight)
        //    {
        //        return -1;
        //    }

        //    return 0;
        //}
    }
}