namespace SWCClasses.Geometry
{
    public class Rectangle : Shape
    {
        #region Instance fields
        private double _xLowerLeft;
        private double _yLowerLeft;
        private double _xUpperRight;
        private double _yUpperRight;
        #endregion

        #region Constructors
        public Rectangle(double xLowerLeft, double yLowerLeft, double xUpperRight, double yUpperRight)
            : base("Rectangle")
        {
            _xLowerLeft = xLowerLeft;
            _yLowerLeft = yLowerLeft;
            _xUpperRight = xUpperRight;
            _yUpperRight = yUpperRight;
        }

        public Rectangle(Point lowerLeft, Point upperRight)
            : this(lowerLeft.X, lowerLeft.Y, upperRight.X, upperRight.Y)
        {
        }
        #endregion

        #region Properties
        public double XLowerLeft
        {
            get { return _xLowerLeft; }
        }

        public double YLowerLeft
        {
            get { return _yLowerLeft; }
        }

        public double XUpperRight
        {
            get { return _xUpperRight; }
        }

        public double YUpperRight
        {
            get { return _yUpperRight; }
        }

        /// <summary>
        /// Override of base class (abstract) property
        /// </summary>
        public override double Area
        {
            get { return (_xUpperRight - _xLowerLeft) * (_yUpperRight - _yLowerLeft); }
        } 
        #endregion
    }
}