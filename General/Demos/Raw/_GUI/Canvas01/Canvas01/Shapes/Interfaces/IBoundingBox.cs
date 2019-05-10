using Canvas01.Shapes.Base;

namespace Canvas01.Shapes.Interfaces
{
    public interface IBoundingBox
    {
        XY BoundingBoxTopLeft { get; }
        XY BoundingBoxBottomRight { get; }
    }
}