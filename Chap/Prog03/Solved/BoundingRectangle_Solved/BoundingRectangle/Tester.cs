using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace BoundingRectangle
{
    public class Tester
    {
        public void Run()
        {
            // Create some rectangles
            Rectangle r1 = new Rectangle(2, 8, 6, 2);
            Rectangle r2 = new Rectangle(1, 6, 4, 3);
            Rectangle r3 = new Rectangle(3, 5, 9, 3);
            Rectangle r4 = new Rectangle(3, 8, 6, 5);
            Rectangle r5 = new Rectangle(2, 9, 5, 5);
            List<Rectangle> rectangles = new List<Rectangle> { r1, r2, r3, r4, r5 };

            // Print information about rectangles:
            Console.WriteLine("All rectangles");
            rectangles.ForEach(Console.WriteLine);
            Console.WriteLine();

            // Find and print the total area of the rectangles
            double totalAreaBySum = rectangles.Sum(r => r.Area);
            double TotalAreaByAggregate = rectangles.Aggregate(0.0, (ta, rect) => ta + rect.Area);
            Console.WriteLine($"Total area of rectangles (using Sum) is : {totalAreaBySum:F3}");
            Console.WriteLine($"Total area of rectangles (using Aggregate) is : {TotalAreaByAggregate:F3}");
            Console.WriteLine();

            // Find and print the bounding rectangle. 
            Rectangle boundingRect = rectangles.Aggregate(r1, Rectangle.CalculateBoundingRectangle);
            Console.WriteLine($"Bounding rectangle is :   {boundingRect}");
        }
    }
}