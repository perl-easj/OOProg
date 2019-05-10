namespace Canvas01.Shapes.Base
{
    public class XY
    {
        public int X { get; set; }
        public int Y { get; set; }

        public XY() : this(0,0)
        {
        }

        public XY(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}