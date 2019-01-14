namespace BoundingRectangle
{
    /// <summary>
    /// This class represents a simple point in a two-dimensional place.
    /// </summary>
    public class Point
    {
        #region Properties
        public double X { get; set; }
        public double Y { get; set; }
        #endregion

        #region Constructor
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Point at ({X},{Y})";
        } 
        #endregion
    }
}