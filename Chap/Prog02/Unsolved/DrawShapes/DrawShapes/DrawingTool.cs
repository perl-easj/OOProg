using System;

namespace DrawShapes
{
    /// <summary>
    /// A class for very primitive drawing...
    /// </summary>
    public class DrawingTool
    {
        public static void DrawOneStar()
        {
            Console.Write("*");
        }

        public static void DrawOneSpace()
        {
            Console.Write(" ");
        }

        public static void StartNewLine()
        {
            Console.WriteLine();
        }
    }
}