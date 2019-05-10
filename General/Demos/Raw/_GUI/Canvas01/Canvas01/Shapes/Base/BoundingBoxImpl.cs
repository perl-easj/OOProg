using Canvas01.Shapes.Interfaces;

namespace Canvas01.Shapes.Base
{
    public class BoundingBoxImpl : IBoundingBox
    {
        private XY _topLeft;
        private XY _bottomRight;

        public BoundingBoxImpl()
        {
            _topLeft = new XY();
            _bottomRight = new XY();
        }

        public BoundingBoxImpl(XY topLeft, XY bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        public XY BoundingBoxTopLeft
        {
            get { return _topLeft; }
        }

        public XY BoundingBoxBottomRight
        {
            get { return _bottomRight; }
        }
    }
}