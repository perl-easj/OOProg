using WesternStrike.Combat;

namespace WesternStrike.Guns
{
    public class SmithWesson
    {
        public double Damage
        {
            get { return 35 + NumberGenerator.Next(0, 25); }
        }
    }
}