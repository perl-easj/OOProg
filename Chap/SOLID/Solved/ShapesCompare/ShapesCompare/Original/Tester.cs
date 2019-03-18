using System;
using System.Collections.Generic;

// ReSharper disable PossibleLossOfFraction

namespace ShapesCompare.Original
{
    public class Tester
    {
        public void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(2, 5, 8.5),
                new Circle(3, 1.5, 4),
                // new Point(12, -2.5), // Uncomment this to provoke exception
                new Square(0.5, 3, 12),
                // new Square(7, 5, 0), // Uncomment this to provoke exception
                new Square(7, 5, 6.5)
            };

            CompareShapes(shapes, shapes);
        }

        public void CompareShapes(List<IShape> shapesA, List<IShape> shapesB)
        {
            foreach (var sa in shapesA)
            {
                foreach (var sb in shapesB)
                {
                    double ratio = AreaRatio(sa, sb);

                    if (Double.IsNaN(ratio))
                    {
                        throw new ArgumentException("Ratio is undefined (possible division by zero)");
                    }

                    Console.WriteLine($"Area ratio between {sa} and {sb} is {ratio:F3}");
                }
            }
        }

        private double AreaRatio(IShape sa, IShape sb)
        {
            return sa.Area/ sb.Area;
        }
    }
}