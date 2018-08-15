using WesternStrike.Combat;

namespace WesternStrike.Axes
{
    public class Damascus
    {
        public double Damage
        {
            get { return 10 + NumberGenerator.Next(0,10); }
        }
    }
}