using WesternStrike.Combat;

namespace WesternStrike.Rifles
{
    public class Remington
    {
        public double Damage
        {
            get { return 50 + NumberGenerator.Next(0, 20); }
        }
    }
}