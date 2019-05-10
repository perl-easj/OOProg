using Canvas01.Shapes.Interfaces;

namespace Canvas01.Shapes.Base
{
    public class ConfinedShapeImpl : IConfinedShape
    {
        private XY _topLeft;
        private XY _bottomRight;

        public ConfinedShapeImpl()
        {
            _topLeft = new XY();
            _bottomRight = new XY();
        }

        public ConfinedShapeImpl(XY topLeft, XY bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        public XY ConfinedAreaTopLeft
        {
            get { return _topLeft; }
        }

        public XY ConfinedAreaBottomRight
        {
            get { return _bottomRight; }
        }

        public bool AtOrBeyondTop(IBoundingBox bb)
        {
            return bb.BoundingBoxTopLeft.Y <= ConfinedAreaTopLeft.Y;
        }

        public bool AtOrBeyondBottom(IBoundingBox bb)
        {
            return bb.BoundingBoxBottomRight.Y >= ConfinedAreaBottomRight.Y;
        }

        public bool AtOrBeyondLeft(IBoundingBox bb)
        {
            return bb.BoundingBoxTopLeft.X <= ConfinedAreaTopLeft.X;
        }

        public bool AtOrBeyondRight(IBoundingBox bb)
        {
            return bb.BoundingBoxBottomRight.X >= ConfinedAreaBottomRight.X;
        }

        public bool InsideBoundary(IBoundingBox bb)
        {
            return !(AtOrBeyondBottom(bb) || AtOrBeyondTop(bb) || AtOrBeyondLeft(bb) || AtOrBeyondRight(bb));
        }
    }
}
