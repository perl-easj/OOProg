using WesternStrike.Combat;

namespace WesternStrike.Knives
{
    public class BowieKnife
    {
        public double Damage
        {
            get { return 10 + NumberGenerator.Next(0, 15); }
        }
    }
}