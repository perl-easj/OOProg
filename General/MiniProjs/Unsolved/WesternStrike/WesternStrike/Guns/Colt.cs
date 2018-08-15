using WesternStrike.Combat;

namespace WesternStrike.Guns
{
    public class Colt
    {
        public double Damage
        {
            get { return 40 + NumberGenerator.Next(0, 30); }
        }
    }
}