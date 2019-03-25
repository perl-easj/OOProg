using CompositeShapes.Shapes;

namespace CompositeShapes.Interfaces
{
    /// <summary>
    /// General interface for 2-D geometric shapes.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Moves the shape by dx along the x-axis,
        /// and dy along the y-axis.
        /// </summary>
        void Move(double dx, double dy);

        /// <summary>
        /// Resizes the shape by the given factor, in
        /// whichever way this is defined.
        /// </summary>
        void Resize(double factor);

        /// <summary>
        /// Returns the center of the shape, in
        /// whichever way this is defined.
        /// </summary>
        Point Center { get; }
    }
}