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
            AddPolyLines(shapes);
            AddCompositeShapes(shapes);
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

        private void AddPolyLines(List<IShape> shapes)
        {
            Point p1 = new Point(2, 3);
            Point p2 = new Point(5, 8);
            Point p3 = new Point(12, 6);
            Point p4 = new Point(14, 1);
            Point p5 = new Point(0, -6);
            Point p6 = new Point(3, 3);
            Point p7 = new Point(8, -2);

            PolyLine pl1 = new PolyLine(new List<Point>{p1, p2, p3, p4});
            PolyLine pl2 = new PolyLine(new List<Point> { p5, p6, p7 });
            shapes.Add(pl1);
            shapes.Add(pl2);

            PolyLineUsingCompositeShape plucs = new PolyLineUsingCompositeShape(new List<Point>{ p1, p2, p3, p4 });
            shapes.Add(plucs);
        }

        private void AddCompositeShapes(List<IShape> shapes)
        {
            IShape s1 = new Line(new Point(2, 6), new Point(3, 2));
            IShape s2 = new Point(-2, 7);
            IShape s3 = new Circle(new Point(0, 12), 7);
            IShape s4 = new Line(new Point(7, 11), new Point(17, 6));
            IShape s5 = new Rectangle(new Point(-3, 6), new Point(17, -8));
            IShape s6 = new Circle(new Point(5, 19), 3);

            IShape cs1 = new CompositeShape<IShape>(new List<IShape>{s1, s4, s5, s6});
            IShape cs2 = new CompositeShape<IShape>(new List<IShape> { s2, s3, cs1 });

            shapes.Add(cs1);
            shapes.Add(cs2);
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