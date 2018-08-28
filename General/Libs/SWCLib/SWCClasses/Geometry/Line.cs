namespace SWCClasses.Geometry
{
    public class Line : Shape
    {
        #region Instance fields
        private double _xA;
        private double _yA;
        private double _xB;
        private double _yB;
        #endregion

        #region Constructors
        public Line(double xA, double yA, double xB, double yB)
            : base("Line")
        {
            _xA = xA;
            _yA = yA;
            _xB = xB;
            _yB = yB;
        }

        public Line(Point a, Point b)
            : this(a.X, a.Y, b.X, b.Y)
        {
        }
        #endregion

        #region Properties
        public double XA
        {
            get { return _xA; }
        }

        public double YA
        {
            get { return _yA; }
        }

        public double XB
        {
            get { return _xB; }
        }

        public double YB
        {
            get { return _yB; }
        }

        public double Length
        {
            get
            {
                Point a = new Point(_xA, _yA);
                return a.Distance(new Point(_xB, _yB));
            }
        }

        /// <summary>
        /// Override of base class (abstract) property
        /// </summary>
        public override double Area
        {
            get { return 0.0; }
        }
        #endregion
    }
}