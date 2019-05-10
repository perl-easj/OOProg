using System.Collections.Generic;
using Canvas01.Shapes.Base;

namespace Canvas01.Shapes
{
    public class PolyLineShape
    {
        private List<XY> _points;

        public PolyLineShape()
        {
            _points = new List<XY>();
        }

        public void AddPoint(XY p)
        {
            _points.Add(p);
        }

        public List<XY> Points
        {
            get { return _points; }
        }
    }
}