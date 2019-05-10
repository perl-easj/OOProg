using Canvas01.Shapes.Base;

namespace Canvas01.Shapes.Interfaces
{
    public interface IConfinedShape
    {
        XY ConfinedAreaTopLeft { get; }
        XY ConfinedAreaBottomRight { get; }
        bool AtOrBeyondTop(IBoundingBox bb);
        bool AtOrBeyondBottom(IBoundingBox bb);
        bool AtOrBeyondLeft(IBoundingBox bb);
        bool AtOrBeyondRight(IBoundingBox bb);
        bool InsideBoundary(IBoundingBox bb);
    }
}