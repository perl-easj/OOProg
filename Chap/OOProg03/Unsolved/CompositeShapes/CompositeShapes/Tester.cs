using System;
using System.Collections.Generic;
using System.Linq;
using CompositeShapes.Interfaces;
using CompositeShapes.Shapes;

namespace CompositeShapes
{
    public class Tester
    {
        public void Run()
        {
            List<IShape> shapes = new List<IShape>();

            AddSimpleShapes(shapes);
            PrintItems(shapes, "All shapes initially");
            PrintItems(shapes.Select(s => $"{s}, center is {s.Center.ToCoord()}"), "Center of shapes initially");

            ApplyToAll(shapes, s => s.Move(3,4));
            PrintItems(shapes, "Shapes after Move(3,4)");

            ApplyToAll(shapes, s => s.Resize(3));
            PrintItems(shapes, "Shapes after Resize(3)");
            PrintItems(shapes.Select(s => $"{s}, center is {s.Center.ToCoord()}"), "Center of shapes finally");
        }

        private void AddSimpleShapes(List<IShape> shapes)
        {
            shapes.Add(new Line(new Point(2, 6), new Point(3, 2)));
            shapes.Add(new Point(-2, 7));
            shapes.Add(new Circle(new Point(0, 12), 7));
            shapes.Add(new Line(new Point(7, 11), new Point(17, 6)));
            shapes.Add(new Rectangle(new Point(-3, 6), new Point(17, -8)));
            shapes.Add(new Circle(new Point(5, 19), 3));
        }

        private void PrintItems<T>(IEnumerable<T> items, string header)
        {
            Console.WriteLine(header);
            ApplyToAll(items, i => { Console.WriteLine(i); });
            Console.WriteLine();
        }

        private void ApplyToAll<T>(IEnumerable<T> items, Action<T> op)
        {
            foreach (T item in items)
            {
                op(item);
            }
        }
    }
}