using System;

namespace BoundingRectangle
{
    /// <summary>
    /// This class represents a rectangle in a two-dimensional plane.
    /// The rectangle is assumed to have sides which are parallel to
    /// the X- and Y-axes in a standard coordinate system.
    /// With this assumption, a rectangle is then fully defined by two points:
    /// The Top-Left corner of the rectangle.
    /// The Bottom-Right corner of teh rectangle.
    /// </summary>
    public class Rectangle
    {
        #region Properties
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public double Area
        {
            get { return (Math.Abs(TopLeft.X - BottomRight.X) * Math.Abs(TopLeft.Y - BottomRight.Y)); }
        }
        #endregion

        #region Constructor
        public Rectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            // Sanity check: topLeftX must be smaller than bottomRightX, and
            //               topLeftY must be larger than bottomRightY
            if (!(topLeftX < bottomRightX && topLeftY > bottomRightY))
            {
                throw new ArgumentException("Invalid coordinates in Rectangle constructor");
            }

            TopLeft = new Point(topLeftX, topLeftY);
            BottomRight = new Point(bottomRightX, bottomRightY);
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return $"Rectangle TopLeft = ({TopLeft.X},{TopLeft.Y}), " +
                   $"BottomRight = ({BottomRight.X},{BottomRight.Y}), " +
                   $"Area = {Area:F3}";
        }

        /// <summary>
        /// This is the central method for finding a "bounding rectangle":
        /// Given two input rectangles, return the bounding rectangle,
        /// i.e. the rectangle which bounds both input rectangles.
        /// </summary>
        public static Rectangle CalculateBoundingRectangle(Rectangle rectA, Rectangle rectB)
        {
            double newTopLeftX = SelectSmallest(rectA.TopLeft.X, rectB.TopLeft.X);
            double newTopLeftY = SelectLargest(rectA.TopLeft.Y, rectB.TopLeft.Y);
            double newBottomRightX = SelectLargest(rectA.BottomRight.X, rectB.BottomRight.X);
            double newBottomRightY = SelectSmallest(rectA.BottomRight.Y, rectB.BottomRight.Y);

            return new Rectangle(newTopLeftX, newTopLeftY, newBottomRightX, newBottomRightY);
        } 
        #endregion

        #region Helper methods
        private static double SelectSmallest(double a, double b)
        {
            return a < b ? a : b;
        }

        private static double SelectLargest(double a, double b)
        {
            return a > b ? a : b;
        } 
        #endregion
    }
}