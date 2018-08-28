using System;

namespace SWCClasses.Geometry
{
    public class Point : Shape
    {
        #region Instance fields
        private double _x;
        private double _y;
        #endregion

        #region Constructor
        public Point(double x, double y)
            : base("Point")
        {
            _x = x;
            _y = y;
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

        /// <summary>
        /// Override of base class (abstract) property
        /// </summary>
        public override double Area
        {
            get { return 0.0; }
        }
        #endregion

        #region Methods
        public double Distance(Point other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        } 
        #endregion
    }
}