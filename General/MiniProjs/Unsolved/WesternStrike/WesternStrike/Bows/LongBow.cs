using WesternStrike.Combat;

namespace WesternStrike.Bows
{
    public class LongBow
    {
        public double Damage
        {
            get { return 25 + NumberGenerator.Next(0, 10); }
        }
    }
}