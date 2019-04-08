using System;

namespace ReFac.TowardsAdapter.Shared.Drawing
{
    public class DrawLibY
    {
        public void DrawCircle(double x, double y, double r)
        {
            Console.WriteLine($"Drawing a circle at ({x},{y}), r = {r}...");
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Console.WriteLine($"Drawing a line from ({x1},{y1}) to ({x2},{y2})...");
        }
    }
}