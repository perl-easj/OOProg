using ReFac.TowardsAdapter.Shared.Shapes;

namespace ReFac.TowardsAdapter.Shared.Figures
{
    public class House
    {
        public Triangle Roof { get; }
        public Rectangle Body { get; }

        public House(Triangle roof, Rectangle body)
        {
            Roof = roof;
            Body = body;
        }

        public House(Point p) // NB: Not accurately implemented...
        {
            Roof = new Triangle(p, p, p);
            Body = new Rectangle(p, p);
        }
    }
}