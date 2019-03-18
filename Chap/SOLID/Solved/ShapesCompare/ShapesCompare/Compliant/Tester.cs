using System;
using System.Collections.Generic;

// ReSharper disable PossibleLossOfFraction

namespace ShapesCompare.Compliant
{
    public class Tester
    {
        public void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(2, 5, new PositiveDouble(8.5)),
                new Circle(3, 1.5, new PositiveDouble(4)),
                // new Point(12, -2.5), // Cannot compile anymore...
                new Square(0.5, 3, new PositiveDouble(12)),
                // new Square(7, 5, new PositiveDouble(0)), // Uncomment this to provoke exception
                new Square(7, 5, new PositiveDouble(6.5))
            };


            CompareShapes(shapes, shapes);
        }

        public void CompareShapes(List<IShape> shapesA, List<IShape> shapesB)
        {
            foreach (var sa in shapesA)
            {
                foreach (var sb in shapesB)
                {
                    PositiveDouble ratio = AreaRatio(sa, sb);
                    Console.WriteLine($"Area ratio between {sa} and {sb} is {ratio.Value:F3}");
                }
            }
        }

        private PositiveDouble AreaRatio(IShape sa, IShape sb)
        {
            return new PositiveDouble(sa.Area.Value / sb.Area.Value);
        }
    }
}