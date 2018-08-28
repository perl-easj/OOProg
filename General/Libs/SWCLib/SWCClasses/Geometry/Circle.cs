using System;

namespace SWCClasses.Geometry
{
    public class Circle : Shape
    {
        #region Instance fields
        private double _x;
        private double _y;
        private double _radius;
        #endregion

        #region Constructors
        public Circle(double x, double y, double radius)
            : base("Circle")
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public Circle(Point c, double radius)
            : this(c.X, c.Y, radius)
        {
        }
        #endregion

        #region Properties
        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public double Radius
        {
            get { return _radius; }
        }

        /// <summary>
        /// Override of base class (abstract) property
        /// </summary>
        public override double Area
        {
            get { return (Math.PI * _radius * _radius); }
        }
        #endregion
    }
}