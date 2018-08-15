using WesternStrike.Combat;

namespace WesternStrike.Knives
{
    public class DundeeKnife
    {
        public double Damage
        {
            get { return 25 + NumberGenerator.Next(0, 10); }
        }
    }
}