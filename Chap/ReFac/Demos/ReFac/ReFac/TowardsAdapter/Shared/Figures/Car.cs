using System.Collections.Generic;
using ReFac.TowardsAdapter.Shared.Shapes;

namespace ReFac.TowardsAdapter.Shared.Figures
{
    public class Car
    {
        public Circle WheelA { get; }
        public Circle WheelB { get; }
        public Rectangle Body { get; }

        public Car(Circle wheelA, Circle wheelB, Rectangle body)
        {
            WheelA = wheelA;
            WheelB = wheelB;
            Body = body;
        }

        public Car(Point p) // NB: Not accurately implemented...
        {
            WheelA = new Circle(p, 2);
            WheelB = new Circle(p, 2);
            Body = new Rectangle(p, p);
        }
    }
}