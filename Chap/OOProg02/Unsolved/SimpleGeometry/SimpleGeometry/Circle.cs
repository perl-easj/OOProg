namespace SimpleGeometry
{
    public class Circle : Shape
    {
        #region Instance fields
        private double _x;
        private double _y;
        private double _radius;
        #endregion

        #region Constructor
        public Circle(double x, double y, double radius)
            : base("Circle")
        {
            _x = x;
            _y = y;
            _radius = radius;
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