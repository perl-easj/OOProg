using WesternStrike.Combat;

namespace WesternStrike.Rifles
{
    public class Winchester
    {
        public double Damage
        {
            get { return 60 + NumberGenerator.Next(0, 25); }
        }
    }
}