namespace SWCClasses.Geometry
{
    public class Square : Rectangle
    {
        #region Constructors
        public Square(double xLowerLeft, double yLowerLeft, double sideLength)
            : base(xLowerLeft, yLowerLeft, xLowerLeft + sideLength, yLowerLeft + sideLength)
        {
        }

        public Square(Point lowerLeft, double sideLength)
            : this(lowerLeft.X, lowerLeft.Y, sideLength)
        {
        } 
        #endregion
    }
}