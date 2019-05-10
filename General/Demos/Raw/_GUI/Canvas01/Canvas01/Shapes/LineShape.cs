using Canvas01.Shapes.Base;

namespace Canvas01.Shapes
{
    public class LineShape
    {
        public XY From { get; }
        public XY To { get; }

        public LineShape(XY from, XY to)
        {
            From = from;
            To = to;
        }
    }
}