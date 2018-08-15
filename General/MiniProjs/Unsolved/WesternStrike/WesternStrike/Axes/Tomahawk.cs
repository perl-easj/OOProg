using WesternStrike.Combat;

namespace WesternStrike.Axes
{
    public class Tomahawk
    {
        public double Damage
        {
            get { return 10 + NumberGenerator.Next(0, 20); }
        }
    }
}