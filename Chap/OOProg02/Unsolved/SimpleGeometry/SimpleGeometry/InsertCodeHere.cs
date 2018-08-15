using System;
using System.Collections.Generic;

namespace SimpleGeometry
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            List<Shape> shapeList = new List<Shape>();
            shapeList.Add(new Circle(2.0, 3.0, 6.5));
            shapeList.Add(new Rectangle(1.0, 1.0, 4.0, 6.0));
            shapeList.Add(new Circle(6.0, 0.0, 2.0));
            shapeList.Add(new Rectangle(0.0, 2.0, 8.0, 5.5));

            foreach (Shape s in shapeList)
            {
                Console.WriteLine($"A {s.ShapeName} with area {s.Area:F2}");
            }
            Console.WriteLine();

            double totalArea = Shape.FindTotalArea(shapeList);
            Console.WriteLine($"The total area of the shapes is {totalArea:F2}");

            // The LAST line of code should be ABOVE this line
        }
    }
}