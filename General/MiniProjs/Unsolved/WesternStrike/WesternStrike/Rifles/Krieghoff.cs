using WesternStrike.Combat;

namespace WesternStrike.Rifles
{
    public class Krieghoff
    {
        public double Damage
        {
            get { return 70 + NumberGenerator.Next(0, 30); }
        }
    }
}