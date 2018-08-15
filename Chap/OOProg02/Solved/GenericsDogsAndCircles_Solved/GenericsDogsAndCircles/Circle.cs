using System;

namespace GenericsDogsAndCircles
{
    public class Circle : IComparable<Circle>
    {
        #region Instance fields
        private double _radius;
        private double _x;
        private double _y;
        #endregion

        #region Constructor
        public Circle(double radius, double x, double y)
        {
            _radius = radius;
            _x = x;
            _y = y;
        }
        #endregion

        #region Properties
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
        #endregion

        #region Methods
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
            return $"Circle at ({X} , {Y}) has an area of {Area.ToString().Substring(0, 6)}";
        } 
        #endregion
    }
}