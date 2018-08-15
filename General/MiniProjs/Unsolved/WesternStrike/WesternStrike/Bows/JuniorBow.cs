using WesternStrike.Combat;

namespace WesternStrike.Bows
{
    public class JuniorBow
    {
        public double Damage
        {
            get { return 15 + NumberGenerator.Next(0, 5); }
        }
    }
}