using WesternStrike.Combat;

namespace WesternStrike.Knives
{
    public class GutterKnife
    {
        public double Damage
        {
            get { return 15 + NumberGenerator.Next(0, 5); }
        }
    }
}