namespace ReFac.TowardsAdapter.Shared.Shapes
{
    public class Triangle
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}