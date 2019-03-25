using System.Collections.Generic;
using System.Linq;
using CompositeShapes.Interfaces;

namespace CompositeShapes.Shapes
{
    /// <summary>
    /// A CompositeShape is a set of objects implementing
    /// the IShape interface. Note that CompositeShape itself
    /// also implements IShape.
    /// The type parameter makes it possible to use CompositeShape
    /// in a more restrictive manner, e.g. to restrict it to
    /// only contain Point objects.
    /// </summary>
    public class CompositeShape<T> : IShape where T : IShape
    {
        private List<T> _shapes;

        public CompositeShape(List<T> shapes)
        {
            _shapes = shapes;
        }

        /// <summary>
        /// A CompositeShape is moved by moving each individual shapes.
        /// </summary>
        public void Move(double dx, double dy)
        {
            _shapes.ForEach(s => s.Move(dx, dy));
        }

        /// <summary>
        /// A CompositeShape is resized by resizing each individual shapes.
        /// </summary>
        public void Resize(double factor)
        {
            _shapes.ForEach(s => s.Resize(factor));
        }

        /// <summary>
        /// The center of a CompositeShape is the average
        /// of the centers for the individual shapes.
        /// </summary>
        public Point Center
        {
            get
            {
                double avX = _shapes.Average(s => s.Center.X);
                double avY = _shapes.Average(s => s.Center.Y);
                return new Point(avX, avY);
            }
        }

        public override string ToString()
        {
            string desc = $"A Composite Shape :\n";
            _shapes.ForEach(p => { desc += $"  {p.ToString()}\n"; });
            return desc;
        }
    }
}