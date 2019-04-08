using ReFac.TowardsAdapter.Shared.Shapes;

namespace ReFac.TowardsAdapter.Shared.Figures
{
    public class Train
    {
        public Circle WheelA { get; }
        public Circle WheelB { get; }
        public Circle WheelC { get; }
        public Rectangle BodyA { get; }
        public Rectangle BodyB { get; }

        public Train(Circle wheelA, Circle wheelB, Circle wheelC, Rectangle bodyA, Rectangle bodyB)
        {
            WheelA = wheelA;
            WheelB = wheelB;
            WheelC = wheelC;
            BodyA = bodyA;
            BodyB = bodyB;
        }

        public Train(Point p) // NB: Not accurately implemented...
        {
            WheelA = new Circle(p, 2);
            WheelB = new Circle(p, 2);
            WheelC = new Circle(p, 2);
            BodyA = new Rectangle(p, p);
            BodyB = new Rectangle(p, p);
        }
    }
}