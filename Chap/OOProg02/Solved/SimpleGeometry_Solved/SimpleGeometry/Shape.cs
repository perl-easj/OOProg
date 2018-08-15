using System.Collections.Generic;

namespace SimpleGeometry
{
    /// <summary>
    /// This class is intended to act as
    /// a base class for geometric shapes
    /// </summary>
    public abstract class Shape
    {
        private string _shapeName;

        protected Shape(string shapeName)
        {
            _shapeName = shapeName;
        }

        public string ShapeName
        {
            get { return _shapeName; }
        }

        public abstract double Area { get; }

        public static double FindTotalArea(List<Shape> shapes)
        {
            double totalArea = 0;
            foreach (Shape s in shapes)
            {
                totalArea = totalArea + s.Area;
            }

            return totalArea;
        }
    }
}
