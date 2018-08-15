using System;

namespace FunctionExample
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            double rect1x1 = 4.5;
            double rect1y1 = 2.3;
            double rect1x2 = 8.2;
            double rect1y2 = 4.9;

            double area1 = Math.Abs((rect1x1 - rect1x2) * (rect1y1 - rect1y2));
            Console.WriteLine($"Area of first rectangle is {area1}");

            double rect2x1 = -3.2;
            double rect2y1 = 1.1;
            double rect2x2 = 3.7;
            double rect2y2 = 5.6;

            double area2 = Math.Abs((rect2x1 - rect2x2) * (rect2y1 - rect2y2));
            Console.WriteLine($"Area of second rectangle is {area2}");


            // The LAST line of code should be ABOVE this line
        }

        public double AreaOfRectangle(double x1, double y1, double x2, double y2)
        {
            // Implement AreaOfRectangle, such that it returns the area
            // of a rectangle defined by (x1, y1) and (x2, y2)
            return 0.0;
        }
    }
}