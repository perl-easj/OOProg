namespace SimpleGeometry
{
    public class Rectangle : Shape
    {
        #region Instance fields
        private double _xLowerLeft;
        private double _yLowerLeft;
        private double _xUpperRight;
        private double _yUpperRight;
        #endregion

        #region Constructor
        public Rectangle(double xLowerLeft, double yLowerLeft, double xUpperRight, double yUpperRight)
            : base("Rectangle")
        {
            _xLowerLeft = xLowerLeft;
            _yLowerLeft = yLowerLeft;
            _xUpperRight = xUpperRight;
            _yUpperRight = yUpperRight;
        }
        #endregion

        /// <summary>
        /// Override of base class (abstract) property
        /// </summary>
        public override double Area
        {
            // This needs to be changed
            get { return 0; }
        }
    }
}