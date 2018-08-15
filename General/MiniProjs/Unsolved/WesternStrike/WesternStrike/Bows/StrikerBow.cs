using WesternStrike.Combat;

namespace WesternStrike.Bows
{
    public class StrikerBow
    {
        public double Damage
        {
            get { return 20 + NumberGenerator.Next(0, 30); }
        }
    }
}