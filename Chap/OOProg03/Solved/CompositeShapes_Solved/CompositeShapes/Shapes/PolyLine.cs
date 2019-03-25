using System.Collections.Generic;
using System.Linq;
using CompositeShapes.Interfaces;

namespace CompositeShapes.Shapes
{
    /// <summary>
    /// A polyLine is simply a set of N Point objects,
    /// i.e. the PolyLine consists of the line segments
    /// [0 -> 1], [1 -> 2] and so on, until [N-2 -> N-1]
    /// </summary>
    public class PolyLine : IShape
    {
        private List<Point> _points;

        public PolyLine(List<Point> points)
        {
            _points = points;
        }

        /// <summary>
        /// A PolyLine is moved by moving each individual Point
        /// </summary>
        public void Move(double dx, double dy)
        {
            _points.ForEach(s => s.Move(dx, dy));
        }

        /// <summary>
        /// A PolyLine is resized by resizing each individual Point
        /// </summary>
        public void Resize(double factor)
        {
            _points.ForEach(s => s.Resize(factor));
        }

        /// <summary>
        /// The center of a PolyLine is the average
        /// of the Points defining the PolyLine.
        /// </summary>
        public Point Center
        {
            get
            {
                double avX = _points.Average(s => s.Center.X);
                double avY = _points.Average(s => s.Center.Y);
                return new Point(avX, avY);
            }
        }

        public override string ToString()
        {
            string desc = $"A PolyLine :\n";
            _points.ForEach(p => { desc += $"  {p.ToCoord()}\n"; });
            return desc;
        }
    }
}