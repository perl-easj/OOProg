using WesternStrike.Combat;

namespace WesternStrike.Axes
{
    public class DoubleAxe
    {
        public double Damage
        {
            get { return 15 + NumberGenerator.Next(0, 10); }
        }
    }
}