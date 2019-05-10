using System;

namespace GenericsDraft01
{
    public class Circle : IComparable<Circle>
    {
        private double _radius;
        private double _x;
        private double _y;

        public Circle(double radius, double x, double y)
        {
            _radius = radius;
            _x = x;
            _y = y;
        }

        public double Radius
        {
            get { return _radius; }
        }

        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public int CompareTo(Circle other)
        {
            if (Area > other.Area)
            {
                return 1;
            }

            if (Area < other.Area)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return "Circle at (" + X + "," + Y + ") has an area of " + Area.ToString().Substring(0,6);
        }
    }
}