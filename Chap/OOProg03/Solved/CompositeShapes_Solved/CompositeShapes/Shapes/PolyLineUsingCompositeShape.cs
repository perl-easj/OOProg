using System.Collections.Generic;

namespace CompositeShapes.Shapes
{
    /// <summary>
    /// Re-implementation of PolyLine, using CompositeShape
    /// with Point as type parameter, whereby it can only
    /// contain Point objects.
    /// </summary>
    public class PolyLineUsingCompositeShape : CompositeShape<Point>
    {
        public PolyLineUsingCompositeShape(List<Point> shapes) : base(shapes)
        {
        }
    }
}